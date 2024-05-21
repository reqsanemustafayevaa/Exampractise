using Exam.business.CustomExceptions.CommonExceptions;
using Exam.business.CustomExceptions.ImageExceptions;
using Exam.business.Extentions;
using Exam.business.services.Interfaces;
using Exam.Core.Models;
using Exam.Core.repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.business.services.Implementations
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IWebHostEnvironment _env;

        public DoctorService(IDoctorRepository doctorRepository,IWebHostEnvironment env)
        {
            _doctorRepository = doctorRepository;
           _env = env;
        }
        public async Task CreateAsync(Doctor doctor)
        {
            if(doctor == null)
            {
                throw new EntityNotfoundException();
            }
            if(doctor.ImageFile is not null)
            {
                if(doctor.ImageFile.ContentType!="image/png" && doctor.ImageFile.ContentType != "image/jpeg")
                {
                    throw new ImageContentException("ImageFile", "ImageFile must be .png or .jpeg!");
                }
                if (doctor.ImageFile.Length > 1073645)
                {
                    throw new ImageSizeException("ImageFile", "ImageFile must be lower than 1mb!");
                }
                doctor.ImageUrl = doctor.ImageFile.SaveFile(_env.WebRootPath, "uploads/doctors");

            }
            doctor.IsDeleted= false;
            doctor.CreateDate = DateTime.UtcNow;
            doctor.UpdateDate = DateTime.UtcNow;
            await _doctorRepository.CreateAsync(doctor);
            await _doctorRepository.CommitAsync();

        }

        public async Task Delete(int id)
        {
            var existfeature = await _doctorRepository.GetSingleAsync(x => x.Id == id);
            if (existfeature is null)
            {
                throw new EntityNotfoundException();
            }
            Helper.DeleteFile(_env.WebRootPath, "uploads/doctors", existfeature.ImageUrl);
            _doctorRepository.Delete(existfeature);
            await _doctorRepository.CommitAsync();
        }
        public async Task<List<Doctor>> GetAllAsync()
        {
            return await _doctorRepository.GetAllAsync().ToListAsync();
        }

        public Task<Doctor> GetByIdAsync(int id)
        {
            var doctor=_doctorRepository.GetSingleAsync(x => x.Id==id);
            if(doctor == null)
            {
                throw new EntityNotfoundException();
            }
            return doctor;
        }

        public async Task UpdateAsync(Doctor doctor)
        {
            var existdoctor=await _doctorRepository.GetSingleAsync(x=>x.Id==doctor.Id);
            if(existdoctor == null)
            {
                throw new EntityNotfoundException();
            }
            if(doctor.ImageFile is not null)
            {
                if (doctor.ImageFile is not null)
                {
                    if (doctor.ImageFile.ContentType != "image/png" && doctor.ImageFile.ContentType != "image/jpeg")
                    {
                        throw new ImageContentException("ImageFile", "ImageFile must be .png or .jpeg!");
                    }
                    if (doctor.ImageFile.Length > 1073645)
                    {
                        throw new ImageSizeException("ImageFile", "ImageFile must be lower than 1mb!");
                    }
                    Helper.DeleteFile(_env.WebRootPath, "uploads/doctors", existdoctor.ImageUrl);
                    existdoctor.ImageUrl=doctor.ImageFile.SaveFile(_env.WebRootPath, "uploads/doctors");

                }
            }
            existdoctor.Name = doctor.Name;
            existdoctor.Position = doctor.Position;
            existdoctor.IsDeleted = false;
            existdoctor.UpdateDate = DateTime.UtcNow;
            await _doctorRepository.CommitAsync();


        }
    }
}

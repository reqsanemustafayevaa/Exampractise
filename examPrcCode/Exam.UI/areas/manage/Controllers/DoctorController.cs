using Exam.business.CustomExceptions.CommonExceptions;
using Exam.business.CustomExceptions.ImageExceptions;
using Exam.business.services.Interfaces;
using Exam.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Exam.UI.Areas.manage.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    [Area("manage")]
    public class DoctorController : Controller
    {
       
        private readonly IDoctorService _doctorservice;

        
        public DoctorController(IDoctorService doctorservice)
        {
            _doctorservice = doctorservice;
        }
        public async Task<IActionResult> Index()
        {

           var doctors=await _doctorservice.GetAllAsync();
            return View(doctors);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                await _doctorservice.CreateAsync(doctor);
            }
            catch(EntityNotfoundException)
            {
                return View ("error");
            }
            catch(ImageContentException ex)
            {
                ModelState.AddModelError(ex.Propertyname, ex.Message);
                return View();
            }
            catch(ImageSizeException ex)
            {
                ModelState.AddModelError(ex.Propertyname,ex.Message);   
                return View();
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var existdoctor=await _doctorservice.GetByIdAsync(id);
            if(existdoctor == null)
            {
                return View("error");
            }
            return View(existdoctor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Doctor doctor)
        {
            if(!ModelState.IsValid)
            {
                return View(doctor) ;
            }
            try
            {
                await _doctorservice.UpdateAsync(doctor);
            }
            catch (EntityNotfoundException)
            {
                return View("error");
            }
            catch (ImageContentException ex)
            {
                ModelState.AddModelError(ex.Propertyname, ex.Message);
                return View();
            }
            catch (ImageSizeException ex)
            {
                ModelState.AddModelError(ex.Propertyname, ex.Message);
                return View();
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var existDoctor = await _doctorservice.GetByIdAsync(id);
            if(existDoctor == null)
            {
                return View("error");
            }
            return View(existDoctor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Doctor doctor)
        {
            try
            {
                await _doctorservice.Delete(doctor.Id);
            }
            catch (EntityNotfoundException)
            {
                return View("error");
            }
            return RedirectToAction("index");
            
        }

    }
}

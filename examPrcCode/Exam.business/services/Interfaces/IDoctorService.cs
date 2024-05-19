using Exam.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.business.services.Interfaces
{
    public interface IDoctorService
    {
        Task CreateAsync(Doctor doctor);
        Task UpdateAsync(Doctor doctor);
        Task Delete(int id);
        Task<List<Doctor>> GetAllAsync();
        Task<Doctor> GetByIdAsync(int id);
    }
}

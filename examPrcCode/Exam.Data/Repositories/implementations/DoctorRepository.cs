using Exam.Core.Models;
using Exam.Core.repositories.Interfaces;
using Exam.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data.Repositories.implementations
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}

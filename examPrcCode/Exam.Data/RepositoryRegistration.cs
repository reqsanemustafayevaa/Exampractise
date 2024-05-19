using Exam.Core.repositories.Interfaces;
using Exam.Data.Repositories.implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data
{
    public static class RepositoryRegistration
    {
        public static void ServiceRegister(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<IDoctorRepository, DoctorRepository>();
        }
    }
}

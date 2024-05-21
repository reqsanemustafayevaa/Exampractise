using Exam.business.services.Implementations;
using Exam.business.services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.business
{
    public static class ServiceRegistration
    {
        public static void ServiceRegister(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<IDoctorService,DoctorService>();
        }
    }
}

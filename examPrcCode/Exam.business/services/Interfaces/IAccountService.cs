using Exam.business.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.business.services.Interfaces
{
    public interface IAccountService
    {
        Task Login(LoginViewModel loginViewModel);
    }
}

using Exam.business.CustomExceptions.AccountException;
using Exam.business.services.Interfaces;
using Exam.business.ViewModels;
using Exam.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.business.services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountService(UserManager<AppUser>userManager,SignInManager<AppUser>signInManager)
        {
           _userManager = userManager;
           _signInManager = signInManager;
        }
        public async Task Login(LoginViewModel loginViewModel)
        {
            AppUser admin = null;
            admin=await _userManager.FindByNameAsync(loginViewModel.UserName);
            if(admin == null)
            {
                throw new InvalidCredsExceptions("","Username or Password Incorrect!");
            }
            var result = await _signInManager.PasswordSignInAsync(admin,loginViewModel.Password,false,false);
            if (!result.Succeeded)
            {
                throw new InvalidCredsExceptions("", "Username or Password Incorrect!");
            };

          
        }
    }
}

using Exam.business.CustomExceptions.AccountException;
using Exam.business.services.Interfaces;
using Exam.business.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Exam.UI.Areas.manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            try
            {
                await _accountService.Login(loginViewModel);
            }
            catch(InvalidCredsExceptions ex)
            {
                ModelState.AddModelError(ex.Propertyname, ex.Message);
                return View();

            }
            return RedirectToAction("index", "doctor");

        }
    }
}

using Exam.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Exam.UI.areas.manage.Controllers
{
    [Authorize(Roles ="SuperAdmin")]
    [Area("manage")]
    public class DashboardController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(RoleManager<IdentityRole>roleManager,UserManager<AppUser>userManager)
        {
           _roleManager = roleManager;
           _userManager = userManager;
        }


        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> CreateRole()
        {
            var role1 = new IdentityRole("SuperAdmin");
            var role2 = new IdentityRole("Admin");
            var role3 = new IdentityRole("User");
            await _roleManager.CreateAsync(role1);
            await _roleManager.CreateAsync(role2);
            await _roleManager.CreateAsync(role3);
            return Ok();

        }
        public async Task<IActionResult> CreateAdmin()
        {
            var admin = new AppUser
            {
                FullName = "Ragsana Mustafayeva",
                UserName = "SuperAdmin",
            };
            await _userManager.CreateAsync(admin, "Admin200@");
            await _userManager.AddToRoleAsync(admin, "SuperAdmin");
            return Ok();

        }

    }
}

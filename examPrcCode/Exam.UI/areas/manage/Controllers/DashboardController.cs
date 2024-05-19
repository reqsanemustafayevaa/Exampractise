using Microsoft.AspNetCore.Mvc;

namespace Exam.UI.areas.manage.Controllers
{
    public class DashboardController : Controller
    {
        [Area("manage")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

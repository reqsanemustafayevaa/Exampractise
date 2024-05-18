using Microsoft.AspNetCore.Mvc;

namespace Exam.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Exam.UI.Areas.manage.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

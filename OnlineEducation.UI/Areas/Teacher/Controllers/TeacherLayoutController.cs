using Microsoft.AspNetCore.Mvc;

namespace OnlineEducation.UI.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class TeacherLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

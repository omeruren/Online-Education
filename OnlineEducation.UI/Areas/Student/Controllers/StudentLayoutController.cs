using Microsoft.AspNetCore.Mvc;

namespace OnlineEducation.UI.Areas.Student.Controllers
{
    [Area("Student")]
    public class StudentLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

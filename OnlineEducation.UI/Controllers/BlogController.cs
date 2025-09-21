using Microsoft.AspNetCore.Mvc;

namespace OnlineEducation.UI.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

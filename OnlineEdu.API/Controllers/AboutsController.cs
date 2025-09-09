using Microsoft.AspNetCore.Mvc;

namespace OnlineEducation.API.Controllers
{
    public class AboutsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

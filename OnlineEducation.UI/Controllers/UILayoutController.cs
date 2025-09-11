using Microsoft.AspNetCore.Mvc;

namespace OnlineEducation.UI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Layout()
        {
            return View();
        }
    }
}

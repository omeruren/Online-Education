using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.Models;
using System.Diagnostics;

namespace OnlineEducation.UI.Controllers
{
    public class HomeController : Controller
    {
    

        public IActionResult Index()
        {
            return View();
        }

       
    }
}

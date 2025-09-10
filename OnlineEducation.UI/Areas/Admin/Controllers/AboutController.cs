using Microsoft.AspNetCore.Mvc;

namespace OnlineEducation.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class AboutController(HttpClient _client) : Controller
    {
        public IActionResult Index()
        {
            //var values = _client.GetFromJsonAsync();
            return View();
        }
    }
}

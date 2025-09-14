using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineEducation.Entity.Entities;
using OnlineEducation.UI.DTOs.BlogDtos;
using OnlineEducation.UI.Helpers;
using System.Threading.Tasks;

namespace OnlineEducation.UI.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class MyBlogController(UserManager<AppUser> _userManager) : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = await _client.GetFromJsonAsync<List<ResultBlogDto>>("blogs/GetBlogByWriterId/" + user.Id);

            return View(values);
        }
    }
}

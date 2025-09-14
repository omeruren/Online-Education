using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEducation.Entity.Entities;
using OnlineEducation.UI.DTOs.BlogCategoryDtos;
using OnlineEducation.UI.DTOs.BlogDtos;
using OnlineEducation.UI.Helpers;
using OnlineEducation.UI.Validators;
using System.Threading.Tasks;

namespace OnlineEducation.UI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        private readonly UserManager<AppUser> _userManager;

        public BlogController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task CategoryDropDown()
        {
            var categoryList = await _client.GetFromJsonAsync<List<ResultBlogCategoryDto>>("blogCategories");

            List<SelectListItem> categories = (from d in categoryList
                                               select new SelectListItem
                                               {
                                                   Text = d.Name,
                                                   Value = d.BlogCategoryId.ToString()
                                               }).ToList();
            ViewBag.categories = categories;
        }
        public async Task<IActionResult> Index()
        {

            var values = await _client.GetFromJsonAsync<List<ResultBlogDto>>("blogs");
            return View(values);
        }

        public async Task<IActionResult> CreateBlog()
        {
            await CategoryDropDown();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogDto createBlogDto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            createBlogDto.WriterId = user.Id;
            await _client.PostAsJsonAsync("blogs", createBlogDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateBlog(int id)
        {
            await CategoryDropDown();
            var values = await _client.GetFromJsonAsync<UpdateBlogDto>($"blogs/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBlog(UpdateBlogDto updateBlogDto)
        {
            var values = await _client.PutAsJsonAsync("blogs", updateBlogDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteBlog(int id)
        {
            await _client.DeleteAsync($"blogs/{id}");
            return RedirectToAction(nameof(Index));
        }


    }
}

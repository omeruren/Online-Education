using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.DTOs.BlogCategoryDtos;
using OnlineEducation.UI.Helpers;
using OnlineEducation.UI.Validators;

namespace OnlineEducation.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class BlogCategoryController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();


        public async Task<IActionResult> Index()
        {

            var values = await _client.GetFromJsonAsync<List<ResultBlogCategoryDto>>("blogCategories");
            return View(values);
        }

        public IActionResult CreateBlogCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlogCategory(CreateBlogCategoryDto createBlogCategoryDto)
        {
            var validator = new BlogCategoryValidator();
            var result = await validator.ValidateAsync(createBlogCategoryDto);

            if (!result.IsValid)
            {
                foreach(var value in result.Errors)
                {
                    ModelState.AddModelError(value.PropertyName, value.ErrorMessage);
                }
                return View();
            }
            await _client.PostAsJsonAsync("blogCategories", createBlogCategoryDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateBlogCategory(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateBlogCategoryDto>($"blogCategories/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBlogCategory(UpdateBlogCategoryDto updateBlogCategoryDto)
        {
            var values = await _client.PutAsJsonAsync("blogCategories", updateBlogCategoryDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteBlogCategory(int id)
        {
            await _client.DeleteAsync($"blogCategories/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}

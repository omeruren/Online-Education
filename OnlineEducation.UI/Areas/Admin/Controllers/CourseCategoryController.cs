using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.DTOs.CourseCategoryDtos;
using OnlineEducation.UI.Helpers;

namespace OnlineEducation.UI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class CourseCategoryController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {

            var values = await _client.GetFromJsonAsync<List<ResultCourseCategoryDto>>("CourseCategories");
            return View(values);
        }

        public ActionResult CreateCourseCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourseCategory(CreateCourseCategoryDto createCourseCategoryDto)
        {

            await _client.PostAsJsonAsync("CourseCategories", createCourseCategoryDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateCourseCategory(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateCourseCategoryDto>($"CourseCategories/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCourseCategory(UpdateCourseCategoryDto updateCourseCategoryDto)
        {
            var values = await _client.PutAsJsonAsync("CourseCategories", updateCourseCategoryDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteCourseCategory(int id)
        {
            await _client.DeleteAsync($"CourseCategories/{id}");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ShowOnHome(int id)
        {
            await _client.GetAsync("courseCategories/ShowOnHome/" + id);
            return RedirectToAction(nameof(Index)); 

        }
        public async Task<IActionResult> DontShowOnHome(int id)
        {
            await _client.GetAsync("courseCategories/DontShowOnHome/" + id);
            return RedirectToAction(nameof(Index)); 

        }
    }
}

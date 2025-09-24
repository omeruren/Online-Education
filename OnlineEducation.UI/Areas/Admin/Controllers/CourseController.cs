using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEducation.UI.DTOs.CourseCategoryDtos;
using OnlineEducation.UI.DTOs.CourseDtos;
using OnlineEducation.UI.Helpers;
using System.Threading.Tasks;

namespace OnlineEducation.UI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly HttpClient _client;

        public CourseController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("RensEduClient");
        }
        public async Task CourseCategoryDropDown()
        {
            var courseCategoryList = await _client.GetFromJsonAsync<List<ResultCourseCategoryDto>>("courseCategories");

            List<SelectListItem> courseCategories = (from c in courseCategoryList
                                                     select new SelectListItem
                                                     {
                                                         Text = c.CategoryName,
                                                         Value = c.CourseCategoryId.ToString()
                                                     }).ToList();
            ViewBag.courseCategories = courseCategories;
        }

        public async Task<IActionResult> Index()
        {

            var values = await _client.GetFromJsonAsync<List<ResultCourseDto>>("Courses");
            return View(values);
        }

        public async Task<ActionResult> CreateCourse()
        {
            await CourseCategoryDropDown();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(CreateCourseDto createCourseDto)
        {

            await _client.PostAsJsonAsync("Courses", createCourseDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateCourse(int id)
        {
            await CourseCategoryDropDown();
            var values = await _client.GetFromJsonAsync<UpdateCourseDto>($"Courses/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCourse(UpdateCourseDto updateCourseDto)
        {
            var values = await _client.PutAsJsonAsync("Courses", updateCourseDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _client.DeleteAsync($"Courses/{id}");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ShowOnHome(int id)
        {
            await _client.GetAsync("courses/ShowOnHome/" + id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DontShowOnHome(int id)
        {
            await _client.GetAsync("courses/DontShowOnHome/" + id);
            return RedirectToAction(nameof(Index));
        }

    }
}

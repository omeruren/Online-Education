using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.DTOs.CourseDtos;
using OnlineEducation.UI.Helpers;
using System.Threading.Tasks;

namespace OnlineEducation.UI.Controllers
{
    public class CourseController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetCoursesByCategoryId(int id)
        {
            var courses = await _client.GetFromJsonAsync<List<ResultCourseDto>>($"courses/GetCoursesByCategoryId/{id}");
            if (courses != null && courses.Any())
            {
                var courseWithCategory = courses.FirstOrDefault(x => x.CourseCategory != null);
                ViewBag.category = courseWithCategory?.CourseCategory?.CategoryName ?? "Kategori bulunamadı";
            }
            else
            {
                ViewBag.category = "Courses not found";
            }
            return View(courses);

        }
    }
}

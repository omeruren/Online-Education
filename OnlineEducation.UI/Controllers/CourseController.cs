using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.DTOs.CourseDtos;
using OnlineEducation.UI.Helpers;
using System.Threading.Tasks;

namespace OnlineEducation.UI.Controllers
{
    public class CourseController : Controller
    {
        private readonly HttpClient _client;

        public CourseController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("RensEduClient");
        }
        public async Task<IActionResult> Index()
        {
            var courses = await _client.GetFromJsonAsync<List<ResultCourseDto>>("courses");

            return View(courses);
        }

        public async Task<IActionResult> GetCoursesByCategoryId(int id)
        {
            var courses = await _client.GetFromJsonAsync<List<ResultCourseDto>>($"courses/GetCoursesByCategoryId/{id}");


            var category = (from x in courses select x.CourseCategory.CategoryName).FirstOrDefault();
            ViewBag.category = category;
        
       
            return View(courses);

        }
    }
}

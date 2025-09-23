using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEducation.Entity.Entities;
using OnlineEducation.UI.DTOs.CourseDtos;
using OnlineEducation.UI.DTOs.CourseRegisterDtos;
using OnlineEducation.UI.DTOs.CourseVideoDtos;
using OnlineEducation.UI.Helpers;
using System.Threading.Tasks;

namespace OnlineEducation.UI.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize(Roles = "Student")]
    public class CourseRegisterController(UserManager<AppUser> _userManager) : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var result = await _client.GetFromJsonAsync<List<ResultCourseRegisterDto>>($"courseRegisters/GetMyCourses/{user.Id}");
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> RegisterCourse()
        {
            var courseList = await _client.GetFromJsonAsync<List<ResultCourseDto>>("courses");

            ViewBag.courses = (from c in courseList
                               select new SelectListItem
                               {
                                   Text = c.CourseName,
                                   Value = c.CourseId.ToString()
                               }).ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterCourse(CreateCourseRegisterDto createCourseRegisterDto)
        {
            var courseList = await _client.GetFromJsonAsync<List<ResultCourseDto>>("courses");

            ViewBag.courses = (from c in courseList
                               select new SelectListItem
                               {
                                   Text = c.CourseName,
                                   Value = c.CourseId.ToString()
                               }).ToList();
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            createCourseRegisterDto.AppUserId = user.Id;
            var result = await _client.PostAsJsonAsync("courseRegisters", createCourseRegisterDto);

            if (result.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View(createCourseRegisterDto);
        }

        public async Task<IActionResult> CourseVideos(int id)
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseVideoDto>>($"courseVideos/GetCourseVideosByCourseId/{id}");
            ViewBag.CourseName = values.Select(x => x.Course.CourseName).FirstOrDefault();
            return View(values);

        }

    }
}

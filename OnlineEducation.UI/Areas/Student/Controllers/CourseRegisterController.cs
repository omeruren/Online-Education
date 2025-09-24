using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEducation.UI.DTOs.CourseDtos;
using OnlineEducation.UI.DTOs.CourseRegisterDtos;
using OnlineEducation.UI.DTOs.CourseVideoDtos;
using OnlineEducation.UI.Services.TokenServices;

namespace OnlineEducation.UI.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize(Roles = "Student")]
    public class CourseRegisterController : Controller
    {
        private readonly HttpClient _client;
        private readonly ITokenService _tokenService;
        public CourseRegisterController(IHttpClientFactory clientFactory, ITokenService tokenService)
        {
            _client = clientFactory.CreateClient("RensEduClient");
            _tokenService = tokenService;
        }
        public async Task<IActionResult> Index()
        {
            var userId =_tokenService.GetUserId;


            var result = await _client.GetFromJsonAsync<List<ResultCourseRegisterDto>>($"courseRegisters/GetMyCourses/{userId}");
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
            var userId = _tokenService.GetUserId;
            createCourseRegisterDto.AppUserId = userId;
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

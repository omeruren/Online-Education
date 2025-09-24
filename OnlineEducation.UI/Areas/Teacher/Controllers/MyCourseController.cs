using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEducation.Entity.Entities;
using OnlineEducation.UI.DTOs.CourseCategoryDtos;
using OnlineEducation.UI.DTOs.CourseDtos;
using OnlineEducation.UI.DTOs.CourseVideoDtos;
using OnlineEducation.UI.Helpers;
using OnlineEducation.UI.Services.TokenServices;
using System.Threading.Tasks;

namespace OnlineEducation.UI.Areas.Teacher.Controllers
{
    [Authorize(Roles = "Teacher")]
    [Area("Teacher")]
    public class MyCourseController : Controller
    {
        private readonly HttpClient _client;
        private readonly ITokenService _tokenService;

        public MyCourseController(IHttpClientFactory clientFactory, ITokenService tokenService)
        {
            _client = clientFactory.CreateClient("RensEduClient");
            _tokenService = tokenService;
        }



        public async Task<IActionResult> Index()
        {

            var userId = _tokenService.GetUserId;

            var values = await _client.GetFromJsonAsync<List<ResultCourseDto>>("courses/GetCoursesByTeacherId/" + userId);

            return View(values);
        }

        public async Task<IActionResult> CreateCourse()
        {
            var categoryList = await _client.GetFromJsonAsync<List<ResultCourseCategoryDto>>("courseCategories");
            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CourseCategoryId.ToString()
                                               }).ToList();
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(CreateCourseDto createCourseDto)
        {
            var userId = _tokenService.GetUserId;
            createCourseDto.AppUserId = userId;
            createCourseDto.IsShown = false;
            await _client.PostAsJsonAsync("courses", createCourseDto);

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> UpdateCourse(int id)
        {
            var categoryList = await _client.GetFromJsonAsync<List<ResultCourseCategoryDto>>("courseCategories");
            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CourseCategoryId.ToString()
                                               }).ToList();
            ViewBag.Categories = categories;
            var value = await _client.GetFromJsonAsync<UpdateCourseDto>("courses/" + id);
            return View(value);
        }
        public async Task<IActionResult> UpdateCourse(UpdateCourseDto updateCourseDto)
        {
            var userId = _tokenService.GetUserId;
            updateCourseDto.AppUserId = userId;
            await _client.PutAsJsonAsync("courses", updateCourseDto);
            return View();
        }

        public async Task<IActionResult> DeleteCourse(int id)
        {

            await _client.DeleteAsync("courses/" + id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CourseVideos(int id)
        {

            var values = await _client.GetFromJsonAsync<List<ResultCourseVideoDto>>($"courseVideos/GetCourseVideosByCourseId/{id}");
            ViewBag.CourseName = values.Select(x => x.Course.CourseName).FirstOrDefault();
            TempData["courseId"] = id;
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateVideo()
        {
            var courseId = (int)TempData["courseId"];
            var course = await _client.GetFromJsonAsync<ResultCourseDto>($"courses/{courseId}");
            ViewBag.courseName = course.CourseName;
            ViewBag.courseId = course.CourseId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateVideo(CreateCourseVideoDto createCourseVideoDto)
        {

            await _client.PostAsJsonAsync("courseVideos", createCourseVideoDto);
            return RedirectToAction(nameof(Index));
        }
    }
}

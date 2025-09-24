using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.DTOs.UserDtos;

namespace OnlineEducation.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class StudentListController : Controller
    {
        private readonly HttpClient _client;

        public StudentListController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("RensEduClient");
        }

        public async Task<IActionResult> Index()
        {
            var students = await _client.GetFromJsonAsync<List<ResultUserDto>>("users/StudentList");
            return View(students);
        }
    }
}

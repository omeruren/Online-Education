using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineEducation.Entity.Entities;
using OnlineEducation.UI.DTOs.UserDtos;
using System.Threading.Tasks;

namespace OnlineEducation.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class TeacherListController: Controller
    {
        private readonly HttpClient _client;

        public TeacherListController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("RensEduClient");
        }

        public async Task<IActionResult> Index()
        {
            var teachers = await _client.GetFromJsonAsync<List<ResultUserDto>>("users/TeacherList");
            return View(teachers);
        }
    }
}

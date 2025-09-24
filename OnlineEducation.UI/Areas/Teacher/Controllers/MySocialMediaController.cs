using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineEducation.Entity.Entities;
using OnlineEducation.UI.DTOs.TeacherSocialDtos;
using OnlineEducation.UI.Helpers;
using OnlineEducation.UI.Services.TokenServices;
using System.Threading.Tasks;

namespace OnlineEducation.UI.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    [Authorize(Roles = "Teacher")]
    public class MySocialMediaController : Controller
    {
        private readonly HttpClient _client;
        private readonly TokenService _tokenService;
        public MySocialMediaController(IHttpClientFactory clientFactory, TokenService tokenService)
        {
            _client = clientFactory.CreateClient("RensEduClient");
            _tokenService = tokenService;
        }
        public async Task<IActionResult> Index()
        {
            var userId = _tokenService.GetUserId;
            var values = await _client.GetFromJsonAsync<List<ResultTeacherSocialDto>>($"teacherSocials/byTeacherId/{userId}");

            return View(values);
        }


        public IActionResult CreateTeacherSocial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeacherSocial(CreateTeacherSocialDto createTeacherSocialDto)
        {
            var userId = _tokenService.GetUserId;
            createTeacherSocialDto.TeacherId = userId;
            await _client.PostAsJsonAsync("teacherSocials", createTeacherSocialDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateTeacherSocial(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateTeacherSocialDto>($"teacherSocials/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTeacherSocial(UpdateTeacherSocialDto updateTeacherSocialDto)
        {
            var values = await _client.PutAsJsonAsync("teacherSocials", updateTeacherSocialDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteTeacherSocial(int id)
        {
            await _client.DeleteAsync($"teacherSocials/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}

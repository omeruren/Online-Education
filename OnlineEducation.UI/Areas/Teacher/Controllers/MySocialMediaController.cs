using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineEducation.Entity.Entities;
using OnlineEducation.UI.DTOs.TeacherSocialDtos;
using OnlineEducation.UI.Helpers;
using System.Threading.Tasks;

namespace OnlineEducation.UI.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    [Authorize(Roles ="Teacher")]
    public class MySocialMediaController(UserManager<AppUser> _userManager) : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = await _client.GetFromJsonAsync<List<ResultTeacherSocialDto>>($"teacherSocials/byTeacherId/{user.Id}");

            return View(values);
        }


        public IActionResult CreateTeacherSocial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeacherSocial(CreateTeacherSocialDto createTeacherSocialDto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            createTeacherSocialDto.TeacherId = user.Id;
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
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
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

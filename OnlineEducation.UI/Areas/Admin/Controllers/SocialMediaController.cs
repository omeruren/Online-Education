using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEducation.UI.DTOs.SocialMediaDtos;
using OnlineEducation.UI.Helpers;

namespace OnlineEducation.UI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class SocialMediaController : Controller
    {
        

        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {

            var values = await _client.GetFromJsonAsync<List<ResultSocialMediaDto>>("SocialMedias");
            return View(values);
        }

        public  IActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {

            await _client.PostAsJsonAsync("SocialMedias", createSocialMediaDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateSocialMediaDto>($"SocialMedias/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var values = await _client.PutAsJsonAsync("SocialMedias", updateSocialMediaDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            await _client.DeleteAsync($"SocialMedias/{id}");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ShowOnHome(int id)
        {
            await _client.GetAsync("SocialMedias/ShowOnHome/" + id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DontShowOnHome(int id)
        {
            await _client.GetAsync("SocialMedias/DontShowOnHome/" + id);
            return RedirectToAction(nameof(Index));
        }
    }
}

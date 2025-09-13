using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.DTOs.SubscriberDtos;
using OnlineEducation.UI.Helpers;

namespace OnlineEducation.UI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class SubscriberController : Controller
    {


        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {

            var values = await _client.GetFromJsonAsync<List<ResultSubscriberDto>>("Subscribers");
            return View(values);
        }

        public IActionResult CreateSubscriber()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubscriber(CreateSubscriberDto createSubscriberDto)
        {

            await _client.PostAsJsonAsync("Subscribers", createSubscriberDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateSubscriber(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateSubscriberDto>($"Subscribers/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSubscriber(UpdateSubscriberDto updateSubscriberDto)
        {
            var values = await _client.PutAsJsonAsync("Subscribers", updateSubscriberDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteSubscriber(int id)
        {
            await _client.DeleteAsync($"Subscribers/{id}");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ShowOnHome(int id)
        {
            await _client.GetAsync("Subscribers/ShowOnHome/" + id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DontShowOnHome(int id)
        {
            await _client.GetAsync("Subscribers/DontShowOnHome/" + id);
            return RedirectToAction(nameof(Index));
        }
    }
}

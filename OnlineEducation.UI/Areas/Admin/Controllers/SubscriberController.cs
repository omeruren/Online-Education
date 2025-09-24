using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.DTOs.SubscriberDtos;
using OnlineEducation.UI.Helpers;

namespace OnlineEducation.UI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class SubscriberController : Controller
    {


        private readonly HttpClient _client;

        public SubscriberController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("RensEduClient");
        }
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

        public async Task<IActionResult> ChangeStatusSubscriber(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateSubscriberDto>($"Subscribers/{id}");
            if (value.IsActive)
            {
                value.IsActive = false;
            }
            else
            {
                value.IsActive = true;
            }

            await _client.PutAsJsonAsync("Subscribers", value);

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeleteSubscriber(int id)
        {
            await _client.DeleteAsync($"Subscribers/{id}");
            return RedirectToAction(nameof(Index));
        }

      
    }
}

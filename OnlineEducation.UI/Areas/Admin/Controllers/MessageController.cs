using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.DTOs.MessageDtos;
using OnlineEducation.UI.Helpers;

namespace OnlineEducation.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class MessageController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {

            var values = await _client.GetFromJsonAsync<List<ResultMessageDto>>("Messages");
            return View(values);
        }

      
        public async Task<IActionResult> MessageDetails(int id)
        {
            var values = await _client.GetFromJsonAsync<ResultMessageDto>($"Messages/{id}");
            return View(values);
        }

      

        public async Task<IActionResult> DeleteMessage(int id)
        {
            await _client.DeleteAsync($"Messages/{id}");
            return RedirectToAction(nameof(Index));
        }

       
    }
}

using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.DTOs.MessageDtos;
using OnlineEducation.UI.Helpers;

namespace OnlineEducation.UI.Controllers
{
    public class ContactController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
        {
            await _client.PostAsJsonAsync("messages", createMessageDto);
            return NoContent();
        }
    }
}

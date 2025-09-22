using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.DTOs.ContactDtos;
using OnlineEducation.UI.DTOs.MessageDtos;
using OnlineEducation.UI.Helpers;
using System.Threading.Tasks;

namespace OnlineEducation.UI.Controllers
{
    public class ContactController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var mapUrls = await _client.GetFromJsonAsync<List<ResultContactDto>>("contacts");
            ViewBag.MapUrls = mapUrls.Select(x => x.MapUrl).FirstOrDefault();
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
        {
            await _client.PostAsJsonAsync("messages", createMessageDto);
            return NoContent();
        }

        public async Task<PartialViewResult> ContactMap()
        {
           
            return PartialView();
        }
    }
}

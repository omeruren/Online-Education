using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.DTOs.SubscriberDtos;
using OnlineEducation.UI.Helpers;
using System.Threading.Tasks;

namespace OnlineEducation.UI.Controllers
{
    public class BlogController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Subscribe(CreateSubscriberDto createSubscriberDto)
        {
            await _client.PostAsJsonAsync("subscribers", createSubscriberDto);

            return NoContent();
        }
    }
}

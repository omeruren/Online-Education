using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.DTOs.AboutDtos;
using OnlineEducation.UI.Helpers;
using System.Threading.Tasks;

namespace OnlineEducation.UI.ViewComponents.Home
{
    public class _HomeAboutComponent : ViewComponent
    {
        private readonly HttpClient _client;

        public _HomeAboutComponent(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("RensEduClient");
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var abouts = await _client.GetFromJsonAsync<List<ResultAboutDto>>("abouts");
            return View(abouts);
        }
    }
}

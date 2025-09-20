using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.DTOs.AboutDtos;
using OnlineEducation.UI.Helpers;
using System.Threading.Tasks;

namespace OnlineEducation.UI.ViewComponents.Home
{
    public class _HomeAboutComponent : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var abouts = await _client.GetFromJsonAsync<List<ResultAboutDto>>("abouts");
            return View(abouts);
        }
    }
}

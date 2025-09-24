using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.DTOs.BannerDtos;
using OnlineEducation.UI.Helpers;
using System.Threading.Tasks;

namespace OnlineEducation.UI.ViewComponents.Home
{
    public class _HomeBannerComponent : ViewComponent
    {
        private readonly HttpClient _client;

        public _HomeBannerComponent(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("RensEduClient");
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBannerDto>>("banners");
            return View(values);
        }
    }
}

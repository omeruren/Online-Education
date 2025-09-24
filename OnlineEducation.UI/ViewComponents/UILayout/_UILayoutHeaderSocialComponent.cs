using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.DTOs.SocialMediaDtos;
using OnlineEducation.UI.Helpers;

namespace OnlineEducation.UI.ViewComponents.UILayout
{
    public class _UILayoutHeaderSocialComponent : ViewComponent
    {
        private readonly HttpClient _client;

        public _UILayoutHeaderSocialComponent(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("RensEduClient");
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultSocialMediaDto>>("socialMedias");
            return View(values);
        }
    }
}

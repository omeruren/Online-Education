using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.DTOs.SocialMediaDtos;
using OnlineEducation.UI.Helpers;

namespace OnlineEducation.UI.ViewComponents.UILayout
{
    public class _UILayoutHeaderSocialComponent : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultSocialMediaDto>>("socialMedias");
            return View(values);
        }
    }
}

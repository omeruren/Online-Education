using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.DTOs.SocialMediaDtos;
using OnlineEducation.UI.Helpers;
using System.Threading.Tasks;

namespace OnlineEducation.UI.ViewComponents.UILayout
{
    public class _UILayoutSocialMediaLinks : ViewComponent
    {
        private readonly  HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var socialLinks = await _client.GetFromJsonAsync<List<ResultSocialMediaDto>>("socialMedias");
            return View(socialLinks);
        }
    }
}

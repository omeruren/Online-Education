using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.DTOs.TestimonialDtos;
using OnlineEducation.UI.Helpers;
using System.Threading.Tasks;

namespace OnlineEducation.UI.ViewComponents.Home
{
    public class _HomeTestimonialComponent : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var testimonials = await _client.GetFromJsonAsync<List<ResultTestimonialDto>>("testimonials");
            return View(testimonials);
        }
    }
}

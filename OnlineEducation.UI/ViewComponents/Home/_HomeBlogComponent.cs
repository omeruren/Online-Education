using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.DTOs.BlogDtos;
using OnlineEducation.UI.Helpers;
using System.Threading.Tasks;

namespace OnlineEducation.UI.ViewComponents.Home
{
    public class _HomeBlogComponent : ViewComponent
    {
        private readonly HttpClient _client;

        public _HomeBlogComponent(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("RensEduClient");
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var blogs = await _client.GetFromJsonAsync<List<ResultBlogDto>>("blogs/GetLastFourBlogs");
            return View(blogs);
        }
    }
}

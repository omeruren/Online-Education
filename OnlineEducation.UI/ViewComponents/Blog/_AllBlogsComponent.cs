using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.DTOs.BlogDtos;
using OnlineEducation.UI.Helpers;
using System.Threading.Tasks;

namespace OnlineEducation.UI.ViewComponents.Blog
{
    public class _AllBlogsComponent : ViewComponent
    {
        private readonly HttpClient _client;

        public _AllBlogsComponent(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("RensEduClient");
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var blogs = await _client.GetFromJsonAsync<List<ResultBlogDto>>("blogs");
            return View(blogs);
        }
    }
}

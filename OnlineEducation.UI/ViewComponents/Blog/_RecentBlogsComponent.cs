using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.DTOs.BlogDtos;
using OnlineEducation.UI.Helpers;
using System.Threading.Tasks;

namespace OnlineEducation.UI.ViewComponents.Blog
{
    public class _RecentBlogsComponent : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = await _client.GetFromJsonAsync<List<ResultBlogDto>>("blogs/GetLastFourBlogs");
            return View(list);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.DTOs.BlogCategoryDtos;
using OnlineEducation.UI.Helpers;
using OnlineEducation.UI.Models;
using System.Threading.Tasks;

namespace OnlineEducation.UI.ViewComponents.Blog
{
    public class _BlogCategoryListComponent : ViewComponent
    {
       private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoryList = await _client.GetFromJsonAsync<List<ResultBlogCategoryDto>>("blogCategories");

            var blogCategories = (from blogCategory in categoryList
                                  select new BlogCatWithCountViewModel
                                  {
                                      CategoryName = blogCategory.Name,
                                      BlogCount = blogCategory.Blogs.Count,
                                      BlogCategoryId = blogCategory.BlogCategoryId
                                  }
                                  ).ToList();

            return View(blogCategories);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.DTOs.CourseCategoryDtos;
using OnlineEducation.UI.Helpers;
using System.Threading.Tasks;

namespace OnlineEducation.UI.ViewComponents.Home
{
    public class _HomeCourseCategoryComponent : ViewComponent
    {
        private readonly HttpClient _client;

        public _HomeCourseCategoryComponent(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("RensEduClient");
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseCategoryDto>>("CourseCategories/GetActiveCategories");

            return View(values);
        }
    }
}

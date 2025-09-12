using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.DTOs.CourseDtos;
using OnlineEducation.UI.Helpers;

namespace OnlineEducation.UI.ViewComponents.Home
{
    public class _HomeCourseComponent : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseDto>>("Courses/GetActiveCourses");

            return View(values);
        }
    }
}

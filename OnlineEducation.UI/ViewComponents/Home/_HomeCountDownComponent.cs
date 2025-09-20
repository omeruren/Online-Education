using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.Helpers;
using OnlineEducation.UI.Services.UserServices;
using System.Threading.Tasks;

namespace OnlineEducation.UI.ViewComponents.Home
{
    public class _HomeCountDownComponent(IUserService _userService): ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.blogCount = await _client.GetFromJsonAsync<int>("blogs/GetBlogCount");
            ViewBag.courseCount = await _client.GetFromJsonAsync<int>("courses/GetCourseCount");
            ViewBag.courseCategoryCount = await _client.GetFromJsonAsync<int>("courseCategories/GetCourseCategoryCount");
            ViewBag.SubscriberCount = await _client.GetFromJsonAsync<int>("Subscribers/GetSubscriberCount");
            return View();
        }
    }
}

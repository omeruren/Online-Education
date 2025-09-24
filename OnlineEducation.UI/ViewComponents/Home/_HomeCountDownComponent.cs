using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.Helpers;
using OnlineEducation.UI.Services.UserServices;
using System.Threading.Tasks;

namespace OnlineEducation.UI.ViewComponents.Home
{
    public class _HomeCountDownComponent: ViewComponent
    {
        private readonly HttpClient _client;
        private readonly IUserService _userService;
        public _HomeCountDownComponent(IHttpClientFactory clientFactory, IUserService userService)
        {
            _client = clientFactory.CreateClient("RensEduClient");
            _userService = userService;
        }
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

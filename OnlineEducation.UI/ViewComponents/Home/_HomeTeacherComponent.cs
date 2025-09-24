using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.DTOs.UserDtos;
using OnlineEducation.UI.Services.UserServices;

namespace OnlineEducation.UI.ViewComponents.Home
{
    public class _HomeTeacherComponent : ViewComponent
    {
        private readonly HttpClient _client;

        public _HomeTeacherComponent(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("RensEduClient");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var teachers = await _client.GetFromJsonAsync<List<ResultUserDto>>("users/GetFourTeachers");
            return View(teachers);
        }
    }
}

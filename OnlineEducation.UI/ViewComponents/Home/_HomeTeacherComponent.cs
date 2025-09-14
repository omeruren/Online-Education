using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.Services.UserServices;

namespace OnlineEducation.UI.ViewComponents.Home
{
    public class _HomeTeacherComponent(IUserService _userService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var teahers = await _userService.GetFourTeachers();
            return View(teahers);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.DTOs.UserDtos;
using OnlineEducation.UI.Services.UserServices;

namespace OnlineEducation.UI.Controllers
{
    public class LoginController(IUserService _userService) : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginDto userLoginDto)
        {
            var userRole = await _userService.LoginAsync(userLoginDto);

            if (userRole == "Admin") { return RedirectToAction("Index", "About", new { area = "Admin" }); }
            if (userRole == "Teacher") { return RedirectToAction("Index", "MyCourse", new { area = "Teacher" }); }
            if (userRole == "Student") { return RedirectToAction("Index", "CourseRegister", new { area = "Student" }); }
            else
            {
                ModelState.AddModelError("", "Email or Password is not correct");
                return View();
            }
        }
    }
}

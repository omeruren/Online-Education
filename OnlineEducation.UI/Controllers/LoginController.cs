using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.DTOs.UserDtos;
using OnlineEducation.UI.Services.UserServices;

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

        if (userRole == "Admin")
            return RedirectToAction("Index", "About", new { area = "Admin" });

        if (userRole == "Teacher")
            return RedirectToAction("Index", "MyCourse", new { area = "Teacher" });

        if (userRole == "Student")
            return RedirectToAction("Index", "CourseRegister", new { area = "Student" });

        ModelState.AddModelError("", "Email or Password is not correct");
        return View();
    }

    [HttpGet]
    public IActionResult AccessDenied()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync("Identity.Application"); // clear cookie
        return RedirectToAction("SignIn", "Login");
    }
}

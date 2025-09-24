using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.DTOs.LoginDtos;
using OnlineEducation.UI.DTOs.UserDtos;
using OnlineEducation.UI.Helpers;
using OnlineEducation.UI.Services.UserServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

public class LoginController : Controller
{
    private readonly HttpClient _client;

    public LoginController(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient("RensEduClient");
    }
    public IActionResult SignIn()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(UserLoginDto userLoginDto)
    {
        var result = await _client.PostAsJsonAsync("users/login", userLoginDto);
        if (!result.IsSuccessStatusCode)
        {
            ModelState.AddModelError("", "Wrong Credantials");
            return View(userLoginDto);
        }

        var handler = new JwtSecurityTokenHandler();
        var response = await result.Content.ReadFromJsonAsync<LoginResponseDto>();
        var token = handler.ReadJwtToken(response.Token);
        var claims = token.Claims.ToList();
        if (response.Token != null)
        {
            claims.Add(new Claim("Token", response.Token));
            var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
            var authProps = new AuthenticationProperties
            {
                ExpiresUtc = response.ExpireDate,
                IsPersistent = true
            };

            await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), authProps);
            return RedirectToAction("Index", "Home");
        }

        ModelState.AddModelError("", "Wrong Credantials");
        return View(userLoginDto);
    }

    [HttpGet]
    public IActionResult AccessDenied()
    {

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(); // clear cookie
        return RedirectToAction("SignIn", "Login");
    }
}

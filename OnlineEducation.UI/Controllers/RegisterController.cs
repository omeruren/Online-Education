using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.DTOs.UserDtos;
using OnlineEducation.UI.Helpers;
using OnlineEducation.UI.Services.UserServices;

namespace OnlineEducation.UI.Controllers
{
    public class RegisterController: Controller
    {
        private readonly HttpClient _client;

        public RegisterController(IHttpClientFactory clientFactory)
        {
           _client = clientFactory.CreateClient("RensEduClient");
        }

        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterDto userRegisterDto)
        {
            var result = await _client.PostAsJsonAsync("users/register", userRegisterDto);
            if (!ModelState.IsValid)
                return View(userRegisterDto);

            if (!result.IsSuccessStatusCode)
            {
                var errors = await result.Content.ReadFromJsonAsync<List<RegisterResponseDto>>();
                foreach (var item in errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(userRegisterDto);
            }
            return RedirectToAction("SignIn", "Login");
        }
    }
}

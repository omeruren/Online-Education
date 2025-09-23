using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineEducation.Business.Abstract;
using OnlineEducation.DTO.DTOs.UserDtos;
using OnlineEducation.Entity.Entities;
using System.Threading.Tasks;

namespace OnlineEducation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersControllercs(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager, IJwtService _jwtService) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null)
                return NotFound("User with this email not found");

            var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, false, false);

            if (!result.Succeeded)
                return BadRequest("Wrong credantials");

            var token = _jwtService.CreateTokenAsync(user);

            return Ok(token);
        }

    }
}

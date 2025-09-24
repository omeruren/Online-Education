using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineEducation.Business.Abstract;
using OnlineEducation.DTO.DTOs.UserDtos;
using OnlineEducation.Entity.Entities;
using System.Threading.Tasks;

namespace OnlineEducation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager, IJwtService _jwtService, IMapper _mapper) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null)
                return NotFound("User with this email not found");

            var result = await _signInManager.PasswordSignInAsync(user, loginDto.Passsword, false, false);

            if (!result.Succeeded)
                return BadRequest("Wrong credantials");

            var token = await _jwtService.CreateTokenAsync(user);

            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var user = _mapper.Map<AppUser>(registerDto);

            if (!ModelState.IsValid)
                return BadRequest("Wrong credantials");

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await _userManager.AddToRoleAsync(user, "Student");

            return Ok("User registration successful");
        }

        [HttpGet("TeacherList")]
        public async Task<IActionResult> TeacherList()
        {
            var teachers = await _userManager.GetUsersInRoleAsync("Teacher");
            return Ok(teachers);
        }

        [HttpGet("StudentList")]
        public async Task<IActionResult> StudentList()
        {
            var students = await _userManager.GetUsersInRoleAsync("Student");
            return Ok(students);
        }

        [HttpGet("GetFourTeachers")]
        public async Task<IActionResult> GetFourTeachers()
        {
            var users = await _userManager.Users.Include(t => t.TeacherSocials).ToListAsync();

            var teachers = users.Where(user => _userManager.IsInRoleAsync(user, "Teacher").Result).OrderByDescending(t => t.Id).Take(4).ToList();

            return Ok(teachers);
        }

    }
}

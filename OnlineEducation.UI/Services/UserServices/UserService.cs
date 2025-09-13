using Microsoft.AspNetCore.Identity;
using NuGet.DependencyResolver;
using OnlineEducation.Entity.Entities;
using OnlineEducation.UI.DTOs.UserDtos;

namespace OnlineEducation.UI.Services.UserServices
{
    public class UserService(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager, RoleManager<AppRole> _roleManager) : IUserService
    {


        public Task<bool> AssignRoleAsync(AssignRoleDto assignRoleDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateRoleAsync(UserRoleDto userRoleDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> CreateUserAsync(UserRegisterDto userRegisterDto)
        {
            var user = new AppUser
            {
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                UserName = userRegisterDto.UserName,
                Email = userRegisterDto.Email,
            };
            if (userRegisterDto.Password != userRegisterDto.ConfirmPassword)
                return new IdentityResult();

            return await _userManager.CreateAsync(user, userRegisterDto.Password);

        }

        public async Task<string> LoginAsync(UserLoginDto userLoginDto)
        {
            var user = await _userManager.FindByEmailAsync(userLoginDto.Email);
            if (user == null) { return null; }
            var result = await _signInManager.PasswordSignInAsync(user, userLoginDto.Passsword, false, false);
            if (!result.Succeeded) { return null; }
            var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
            if (isAdmin) { return "Admin"; }
            var isTeacher = await _userManager.IsInRoleAsync(user, "Teacher");
            if (isTeacher) { return "Teacher"; }
            var isStudent = await _userManager.IsInRoleAsync(user, "Student");
            if (isStudent) { return "Student"; }


            return null;
        }

        public Task<bool> LogoutAsync()
        {
            throw new NotImplementedException();
        }
    }
}

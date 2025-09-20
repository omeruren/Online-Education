using Microsoft.AspNetCore.Identity;
using OnlineEducation.Entity.Entities;
using OnlineEducation.UI.DTOs.UserDtos;

namespace OnlineEducation.UI.Services.UserServices
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(UserRegisterDto userRegisterDto);
        Task<string> LoginAsync(UserLoginDto userLoginDto);
        Task<bool> LogoutAsync();
        Task<bool> CreateRoleAsync(UserRoleDto userRoleDto);
  
        Task<bool> AssignRoleAsync(List<AssignRoleDto> assignRoleDto);
        Task<List<AppUser>> GetAllUserAsync();
        Task<List<ResultUserDto>> GetFourTeachers();
        Task<AppUser> GetUserByIdAsync(int id);
        Task<int> GetTeacherCount();
    }
}

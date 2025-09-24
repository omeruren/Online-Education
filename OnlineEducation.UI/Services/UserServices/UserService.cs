using Microsoft.AspNetCore.Identity;
using OnlineEducation.UI.DTOs.UserDtos;
using OnlineEducation.UI.Models;

namespace OnlineEducation.UI.Services.UserServices
{
    public class UserService: IUserService
    {

        private readonly HttpClient _client;

        public UserService(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("RensEduClient");
        }

        public async Task<bool> AssignRoleAsync(List<AssignRoleDto> assignRoleDto)
        {
            throw new NotImplementedException();

        }

        public Task<bool> CreateRoleAsync(UserRoleDto userRoleDto)
        {
            throw new NotImplementedException();
        }

        public  Task<IdentityResult> CreateUserAsync(UserRegisterDto userRegisterDto)
        {
            throw new NotImplementedException();
        }

        public  Task<List<ResultUserDto>> GetFourTeachers()
        {
            throw new NotImplementedException();

        }

        public Task<List<UserViewModel>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

    

        public async Task<string> LoginAsync(UserLoginDto userLoginDto)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetTeacherCount()
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultUserDto>> GetAllTeachers()
        {
            throw new NotImplementedException();
        }
        public async Task LogoutAsync()
        {
            throw new NotImplementedException();

        }
        public async Task<List<AssignRoleDto>> GetUserForRoleAssign(int id)
        {
            return await _client.GetFromJsonAsync<List<AssignRoleDto>>($"roleAssigns/{id}");
        }
    }
}

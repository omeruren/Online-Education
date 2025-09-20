using OnlineEducation.UI.DTOs.RoleDtos;

namespace OnlineEducation.UI.Services.RoleServices
{
    public interface IRoleService
    {
        Task<List<ResultRoleDto>> GetAllRoleAsync();
        Task<UpdateRoleDto> GetRoleByIdAsync(int id);
        Task CreateRoleAsync(CreateRoleDto createRoleDto);
        Task DeleteRoleAsync(int id);
    }
}

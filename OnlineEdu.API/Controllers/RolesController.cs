using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineEducation.DTO.DTOs.RoleDtos;
using OnlineEducation.Entity.Entities;
using System.Threading.Tasks;

namespace OnlineEducation.API.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController(RoleManager<AppRole> _roleManeger, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _roleManeger.Roles.ToListAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleDto createRoleDto)
        {
            var role = _mapper.Map<AppRole>(createRoleDto);
            var result = await _roleManeger.CreateAsync(role);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok("Role created successful");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = await _roleManeger.Roles.FirstOrDefaultAsync(x => x.Id == id);
            if (role == null)
                return NotFound("Role does not exist");

            await _roleManeger.DeleteAsync(role);
            return Ok("Role deleted successful");
        }
    }
}

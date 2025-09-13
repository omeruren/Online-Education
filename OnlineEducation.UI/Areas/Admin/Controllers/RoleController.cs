using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineEducation.Entity.Entities;
using OnlineEducation.UI.DTOs.RoleDtos;
using OnlineEducation.UI.Services.RoleServices;
using System.Threading.Tasks;

namespace OnlineEducation.UI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class RoleController(IRoleService _roleManager) : Controller
    {

        public async Task<IActionResult> Index()
        {
            var values = await _roleManager.GetAllRoleAsync();

            return View(values);
        }

        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleDto createRoleDto)
        {
            await _roleManager.CreateRoleAsync(createRoleDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            await _roleManager.DeleteRoleAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

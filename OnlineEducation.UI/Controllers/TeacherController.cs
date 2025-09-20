using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.Services.UserServices;
using System.Threading.Tasks;

namespace OnlineEducation.UI.Controllers
{
    public class TeacherController(IUserService _userService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var teachers =  await _userService.GetAllTeachers();
            return View(teachers);
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineEducation.Business.Abstract;
using OnlineEducation.DataAccess.Context;
using OnlineEducation.DTO.DTOs.UserDtos;
using OnlineEducation.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducation.Business.Concrete
{
    public class UserService(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager, RoleManager<AppRole> _roleManager, IMapper _mapper, OnlineEducationContext _context) : IUserService
    {

        public async Task<bool> AssignRoleAsync(List<AssignRoleDto> assignRoleDto)
        {
            throw new NotImplementedException();

        }

        public Task<bool> CreateRoleAsync(UserRoleDto userRoleDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> CreateUserAsync(RegisterDto userRegisterDto)
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

            var result = await _userManager.CreateAsync(user, userRegisterDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Student");
                return result;
            }
            return result;
        }

        public async Task<List<ResultUserDto>> GetFourTeachers()
        {
            var users = await _userManager.Users.Include(t => t.TeacherSocials).ToListAsync();

            var teachers = users.Where(user => _userManager.IsInRoleAsync(user, "Teacher").Result).OrderByDescending(t => t.Id).Take(4).ToList();

            return _mapper.Map<List<ResultUserDto>>(teachers);


        }

        public async Task<List<AppUser>> GetAllUserAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<string> LoginAsync(LoginDto userLoginDto)
        {
            var user = await _userManager.FindByEmailAsync(userLoginDto.Email);
            if (user == null) { return null; }
            var result = await _signInManager.PasswordSignInAsync(user, userLoginDto.Password, false, false);
            if (!result.Succeeded) { return null; }
            var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
            if (isAdmin) { return "Admin"; }
            var isTeacher = await _userManager.IsInRoleAsync(user, "Teacher");
            if (isTeacher) { return "Teacher"; }
            var isStudent = await _userManager.IsInRoleAsync(user, "Student");
            if (isStudent) { return "Student"; }


            return null;
        }

        public async Task<int> GetTeacherCount()
        {
            var teachers = await _userManager.GetUsersInRoleAsync("Teacher");
            return teachers.Count();
        }

        public async Task<List<ResultUserDto>> GetAllTeachers()
        {
            var users = await _userManager.Users.Include(t => t.TeacherSocials).ToListAsync();

            var teachers = users.Where(user => _userManager.IsInRoleAsync(user, "Teacher").Result).ToList();

            return _mapper.Map<List<ResultUserDto>>(teachers);

        }
        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();

        }

       
    }
}

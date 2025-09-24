using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducation.Business.Abstract;
using OnlineEducation.DTO.DTOs.TeacherSocialDtos;
using OnlineEducation.Entity.Entities;

namespace OnlineEducation.API.Controllers
{
    [Authorize(Roles = "Admin,Teacher")]
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherSocialsController(IGenericService<TeacherSocial> _teacherSocialService, IMapper _mapper) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("byTeacherId/{id}")]
        public IActionResult GetSocialByTeacherId(int id)
        {
            var values = _teacherSocialService.TGetFilteredList(t => t.TeacherId == id);
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _teacherSocialService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _teacherSocialService.TDelete(id);
            return Ok("TeacherSocial entitiy deleted");
        }

        [HttpPost]
        public IActionResult Create(CreateTeacherSocialDto createTeacherSocialDto)
        {
            var newValue = _mapper.Map<TeacherSocial>(createTeacherSocialDto);
            _teacherSocialService.TCreate(newValue);
            return Ok("TeacherSocial entitiy created");
        }

        [HttpPut]
        public IActionResult Update(UpdateTeacherSocialDto updateTeacherSocialDto)
        {
            var values = _mapper.Map<TeacherSocial>(updateTeacherSocialDto);
            _teacherSocialService.TUpdate(values);
            return Ok("TeacherSocial entitiy updated");
        }
    }
}

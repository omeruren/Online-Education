using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducation.Business.Abstract;
using OnlineEducation.DTO.DTOs.CourseRegisterDtos;
using OnlineEducation.Entity.Entities;

namespace OnlineEducation.API.Controllers
{
    [Authorize(Roles = "Admin, Student")]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseRegistersController(ICourseRegisterService _courseRegisterService, IMapper _mapper) : ControllerBase
    {
        [HttpGet("GetMyCourses/{userId}")]
        public IActionResult GetMyCourses(int userId)
        {
            var values = _courseRegisterService.TGetAllWithCourseAndCategory(c => c.AppUserId == userId);
            var mappedValues = _mapper.Map<List<ResultCourseRegisterDto>>(values);
            return Ok(mappedValues);
        }

        [HttpPost]
        public IActionResult RegisterToCourse(CreateCourseRegisterDto createCourseRegisterDto)
        {
            var newCourseRegister = _mapper.Map<CourseRegister>(createCourseRegisterDto);
            _courseRegisterService.TCreate(newCourseRegister);
            return Ok("Register to Course successful");
        }

        [HttpPut]
        public IActionResult UpdateCourseRegister(UpdateCourseRegisterDto updateCourseRegisterDto)
        {
            var updatedCourseRegister = _mapper.Map<CourseRegister>(updateCourseRegisterDto);
            _courseRegisterService.TUpdate(updatedCourseRegister);
            return Ok("Updated course record");
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var value = _courseRegisterService.TGetById(id);
            var mappedValue = _mapper.Map<ResultCourseRegisterDto>(value);
            return Ok(mappedValue);

        }


        [HttpDelete("{id}")]
        public IActionResult DeleteCourseRegister(int id)
        {
            _courseRegisterService.TDelete(id);
            return Ok("course record deleted");
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducation.Business.Abstract;
using OnlineEducation.DTO.DTOs.CourseDtos;
using OnlineEducation.DTO.DTOs.CourseCategoryDtos;
using OnlineEducation.Entity.Entities;

namespace OnlineEducation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController(ICourseService _courseService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _courseService.TGetAllCoursesWithCategories();
            var courses = _mapper.Map<List<ResultCourseDto>>(values);
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _courseService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _courseService.TDelete(id);
            return Ok("Course entitiy deleted");
        }

        [HttpPost]
        public IActionResult Create(CreateCourseDto createCourseDto)
        {

            var newValue = _mapper.Map<Course>(createCourseDto);
            _courseService.TCreate(newValue);
            return Ok("Course entitiy created");
        }

        [HttpPut]
        public IActionResult Update(UpdateCourseDto updateCourseDto)
        {
            var values = _mapper.Map<Course>(updateCourseDto);
            _courseService.TUpdate(values);
            return Ok("Course entitiy updated");
        }

        [HttpGet("ShowOnHome/{id}")]
        public IActionResult ShowOnHome(int id)
        {
            _courseService.TShowOnHome(id);
            return Ok("Showing On Home Page");
        }
        [HttpGet("DontShowOnHome/{id}")]
        public IActionResult DontShowOnHome(int id)
        {
            _courseService.TDontShowOnHome(id);
            return Ok("Do not Showing On Home Page");
        }

        [HttpGet("GetActiveCourses")]

        public IActionResult GetActiveCourses()
        {
            var values = _courseService.TGetFilteredList(c => c.IsShown == true);
            return Ok(values);
        }
        [HttpGet("GetCoursesByTeacherId/{id}")]

        public IActionResult GetCoursesByTeacherId(int id)
        {
            var values = _courseService.TGetCoursesByTeacherId(id);
            var mappedValues = _mapper.Map<List<ResultCourseDto>>(values);
            return Ok(mappedValues);

        }
    }
}

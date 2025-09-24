using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducation.Business.Abstract;
using OnlineEducation.DTO.DTOs.CourseCategoryDtos;
using OnlineEducation.Entity.Entities;

namespace OnlineEducation.API.Controllers
{
    [Authorize(Roles = "Admin, Teacher")]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCategoriesController(ICourseCategoryService _courseCategory, IMapper _mapper) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            var values = _courseCategory.TGetList();
            var courseCategories = _mapper.Map<List<ResultCourseCategoryDto>>(values);
            return Ok(courseCategories);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _courseCategory.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _courseCategory.TDelete(id);
            return Ok("CourseCategory entitiy deleted");
        }

        [HttpPost]
        public IActionResult Create(CreateCourseCategoryDto createCourseCategoryDto)
        {
            var newValue = _mapper.Map<CourseCategory>(createCourseCategoryDto);
            _courseCategory.TCreate(newValue);
            return Ok("CourseCategory entitiy created");
        }

        [HttpPut]
        public IActionResult Update(UpdateCourseCategoryDto updateCourseCategoryDto)
        {
            var values = _mapper.Map<CourseCategory>(updateCourseCategoryDto);
            _courseCategory.TUpdate(values);
            return Ok("CourseCategory entitiy updated");
        }

        [HttpGet("ShowOnHome/{id}")]
        public IActionResult ShowOnHome(int id)
        {
            _courseCategory.TShowOnHome(id);
            return Ok("Showing on Home Page");
        }

        [HttpGet("DontShowOnHome/{id}")]
        public IActionResult DontShowOnHome(int id)
        {
            _courseCategory.TDontShowOnHome(id);
            return Ok("Do not Showing on Home Page");
        }

        [AllowAnonymous]
        [HttpGet("GetActiveCategories")]
        public IActionResult GetActiveCategories()
        {
            var values = _courseCategory.TGetFilteredList(c => c.IsShown == true);
            return Ok(values);
        }
        [AllowAnonymous]
        [HttpGet("GetCourseCategoryCount")]
        public IActionResult GetCourseCategoryCount()
        {
            var courseCategories = _courseCategory.TCount();
            return Ok(courseCategories);
        }
    }
}

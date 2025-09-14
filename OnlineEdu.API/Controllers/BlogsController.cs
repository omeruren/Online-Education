using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducation.Business.Abstract;
using OnlineEducation.DTO.DTOs.BlogDtos;
using OnlineEducation.Entity.Entities;

namespace OnlineEducation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController(IBlogService _blogService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _blogService.TGetBlogsWithCategories();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _blogService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _blogService.TDelete(id);
            return Ok("Blog entitiy deleted");
        }

        [HttpPost]
        public IActionResult Create(CreateBlogDto createBlogDto)
        {
            var newValue = _mapper.Map<Blog>(createBlogDto);
            _blogService.TCreate(newValue);
            return Ok("Blog entitiy created");
        }

        [HttpPut]
        public IActionResult Update(UpdateBlogDto updateBlogDto)
        {
            var values = _mapper.Map<Blog>(updateBlogDto);
            _blogService.TUpdate(values);
            return Ok("Blog entitiy updated");
        }
        [HttpGet("GetBlogByWriterId/{id}")]
        public IActionResult GetBlogByWriterId(int id)
        {
            var values = _blogService.TGetBlogsWithCategoriesByWriterId(id);
            var blogs = _mapper.Map<List<ResultBlogDto>>(values);
            return Ok(blogs);
        }
    }
}

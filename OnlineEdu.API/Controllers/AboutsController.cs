using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducation.Business.Abstract;
using OnlineEducation.DTO.DTOs.AboutDtos;
using OnlineEducation.Entity.Entities;

namespace OnlineEducation.API.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController(IGenericService<About> _aboutService, IMapper _mapper) : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            var values = _aboutService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _aboutService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _aboutService.TDelete(id);
            return Ok("About entitiy deleted");
        }

        [HttpPost]
        public IActionResult Create(CreateAboutDto createAboutDto)
        {
            var newValue = _mapper.Map<About>(createAboutDto);
            _aboutService.TCreate(newValue);
            return Ok("About entitiy created");
        }

        [HttpPut]
        public IActionResult Update(UpdateAboutDto updateAboutDto)
        {
            var values = _mapper.Map<About>(updateAboutDto);
            _aboutService.TUpdate(values);
            return Ok("About entitiy updated");
        }
    }
}

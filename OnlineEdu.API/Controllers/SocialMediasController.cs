using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducation.Business.Abstract;
using OnlineEducation.DTO.DTOs.SocialMediaDtos;
using OnlineEducation.Entity.Entities;

namespace OnlineEducation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController (IGenericService<SocialMedia> _socialMediaService, IMapper _mapper): ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _socialMediaService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _socialMediaService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _socialMediaService.TDelete(id);
            return Ok("SocialMedia entitiy deleted");
        }

        [HttpPost]
        public IActionResult Create(CreateSocialMediaDto createSocialMediaDto)
        {
            var newValue = _mapper.Map<SocialMedia>(createSocialMediaDto);
            _socialMediaService.TCreate(newValue);
            return Ok("SocialMedia entitiy created");
        }

        [HttpPut]
        public IActionResult Update(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var values = _mapper.Map<SocialMedia>(updateSocialMediaDto);
            _socialMediaService.TUpdate(values);
            return Ok("SocialMedia entitiy updated");
        }
    }
}

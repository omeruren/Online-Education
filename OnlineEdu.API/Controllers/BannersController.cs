using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducation.Business.Abstract;
using OnlineEducation.DTO.DTOs.BannerDtos;
using OnlineEducation.Entity.Entities;

namespace OnlineEducation.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController(IGenericService<Banner> _bannerService, IMapper _mapper) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            var values = _bannerService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _bannerService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bannerService.TDelete(id);
            return Ok("Banner entitiy deleted");
        }

        [HttpPost]
        public IActionResult Create(CreateBannerDto createBannerDto)
        {
            var newValue = _mapper.Map<Banner>(createBannerDto);
            _bannerService.TCreate(newValue);
            return Ok("Banner entitiy created");
        }

        [HttpPut]
        public IActionResult Update(UpdateBannerDto updateBannerDto)
        {
            var values = _mapper.Map<Banner>(updateBannerDto);
            _bannerService.TUpdate(values);
            return Ok("Banner entitiy updated");
        }
    }
}

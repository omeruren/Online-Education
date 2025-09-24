using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducation.Business.Abstract;
using OnlineEducation.DTO.DTOs.ContactDtos;
using OnlineEducation.Entity.Entities;

namespace OnlineEducation.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController(IGenericService<Contact> _contactService, IMapper _mapper) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            var values = _contactService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _contactService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _contactService.TDelete(id);
            return Ok("Contact entitiy deleted");
        }

        [HttpPost]
        public IActionResult Create(CreateContactDto createContactDto)
        {
            var newValue = _mapper.Map<Contact>(createContactDto);
            _contactService.TCreate(newValue);
            return Ok("Contact entitiy created");
        }

        [HttpPut]
        public IActionResult Update(UpdateContactDto updateContactDto)
        {
            var values = _mapper.Map<Contact>(updateContactDto);
            _contactService.TUpdate(values);
            return Ok("Contact entitiy updated");
        }
    }
}

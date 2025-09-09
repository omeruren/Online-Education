using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducation.Business.Abstract;
using OnlineEducation.DTO.DTOs.MessageDtos;
using OnlineEducation.Entity.Entities;

namespace OnlineEducation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController(IGenericService<Message> _messageService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _messageService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _messageService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _messageService.TDelete(id);
            return Ok("Message entitiy deleted");
        }

        [HttpPost]
        public IActionResult Create(CreateMessageDto createMessageDto)
        {
            var newValue = _mapper.Map<Message>(createMessageDto);
            _messageService.TCreate(newValue);
            return Ok("Message entitiy created");
        }

        [HttpPut]
        public IActionResult Update(UpdateMessageDto updateMessageDto)
        {
            var values = _mapper.Map<Message>(updateMessageDto);
            _messageService.TUpdate(values);
            return Ok("Message entitiy updated");
        }
    }
}

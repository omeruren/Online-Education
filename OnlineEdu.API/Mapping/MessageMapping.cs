using AutoMapper;
using OnlineEducation.DTO.DTOs.MessageDtos;
using OnlineEducation.Entity.Entities;

namespace OnlineEducation.API.Mapping
{
    public class MessageMapping : Profile
    {
        public MessageMapping()
        {
            CreateMap<CreateMessageDto, Message>().ReverseMap();
            CreateMap<UpdateMessageDto, Message>().ReverseMap();
        }
    }
}

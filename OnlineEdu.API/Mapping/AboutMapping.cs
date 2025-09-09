using AutoMapper;
using OnlineEducation.DTO.DTOs.AboutDtos;
using OnlineEducation.Entity.Entities;

namespace OnlineEducation.API.Mapping
{
    public class AboutMapping : Profile
    {
        public AboutMapping()
        {
            CreateMap<CreateAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();
        }
    }
}

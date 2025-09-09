using AutoMapper;
using OnlineEducation.DTO.DTOs.SocialMediaDtos;
using OnlineEducation.Entity.Entities;

namespace OnlineEducation.API.Mapping
{
    public class SocialMediaMapping: Profile
    {
        public SocialMediaMapping()
        {
            CreateMap<CreateSocialMediaDto, SocialMedia>().ReverseMap();
            CreateMap<UpdateSocialMediaDto, SocialMedia>().ReverseMap();
        }
    }
}

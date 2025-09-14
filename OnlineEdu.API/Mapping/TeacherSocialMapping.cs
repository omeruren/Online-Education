using AutoMapper;
using OnlineEducation.DTO.DTOs.SocialMediaDtos;
using OnlineEducation.DTO.DTOs.TeacherSocialDtos;
using OnlineEducation.Entity.Entities;

namespace OnlineEducation.API.Mapping
{
    public class TeacherSocialMapping : Profile
    {
        public TeacherSocialMapping()
        {
            CreateMap<TeacherSocial, CreateTeacherSocialDto>().ReverseMap();
            CreateMap<TeacherSocial, UpdateTeacherSocialDto>().ReverseMap();
            CreateMap<TeacherSocial, ResultTeacherSocialDto>().ReverseMap();
        }
    }
}

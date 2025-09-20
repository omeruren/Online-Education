using AutoMapper;
using OnlineEducation.DTO.DTOs.CourseRegisterDtos;
using OnlineEducation.Entity.Entities;

namespace OnlineEducation.API.Mapping
{
    public class CourseRegisterMapping : Profile
    {
        public CourseRegisterMapping()
        {
            CreateMap<CourseRegister, CreateCourseRegisterDto>().ReverseMap();
            CreateMap<CourseRegister, UpdateCourseRegisterDto>().ReverseMap();
            CreateMap<CourseRegister, ResultCourseRegisterDto>().ReverseMap();
        }
    }
}

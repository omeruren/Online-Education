using AutoMapper;
using OnlineEducation.DTO.DTOs.CourseVideoDtos;
using OnlineEducation.Entity.Entities;

namespace OnlineEducation.API.Mapping
{
    public class CourseVideoMapping : Profile
    {
        public CourseVideoMapping()
        {
            CreateMap<CourseVideo,CreateCourseVideoDto>().ReverseMap();
            CreateMap<CourseVideo,UpdateCourseVideoDto>().ReverseMap();
            CreateMap<CourseVideo,ResultCourseVideoDto>().ReverseMap();
        }
    }
}

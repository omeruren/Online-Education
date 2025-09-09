using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OnlineEducation.DTO.DTOs.BlogDtos;
using OnlineEducation.Entity.Entities;

namespace OnlineEducation.API.Mapping
{
    public class BlogMapping:Profile
    {
        public BlogMapping()
        {
            CreateMap<CreateBlogDto, Blog>().ReverseMap();
            CreateMap<UpdateBlogDto, Blog>().ReverseMap();
            CreateMap<ResultBlogDto, Blog>().ReverseMap();
        }
    }
}

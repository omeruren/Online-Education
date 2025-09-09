using AutoMapper;
using OnlineEducation.DTO.DTOs.BlogCategoryDtos;
using OnlineEducation.Entity.Entities;

namespace OnlineEducation.API.Mapping
{
    public class BlogCategoryMapping  : Profile
    {
        public BlogCategoryMapping()
        {
            CreateMap<CreateBlogCategoryDto, BlogCategory>().ReverseMap();
            CreateMap<UpdateBlogCategoryDto, BlogCategory>().ReverseMap();
            CreateMap<ResultBlogCategoryDto, BlogCategory>().ReverseMap();
        }
    }
}

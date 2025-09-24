using AutoMapper;
using OnlineEducation.DTO.DTOs.RoleDtos;
using OnlineEducation.DTO.DTOs.UserDtos;
using OnlineEducation.Entity.Entities;

namespace OnlineEducation.API.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<AppUser, RegisterDto>().ReverseMap();
            CreateMap<AppRole, CreateRoleDto>().ReverseMap();
            CreateMap<AppRole, UpdateRoleDto>().ReverseMap();
            CreateMap<AppUser, ResultUserDto>().ReverseMap();
        }
    }
}

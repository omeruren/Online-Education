using AutoMapper;
using OnlineEducation.DTO.DTOs.RoleDtos;
using OnlineEducation.Entity.Entities;

namespace OnlineEducation.API.Mapping
{
    public class RoleMapping : Profile
    {
        public RoleMapping()
        {
            CreateMap<AppRole, CreateRoleDto>().ReverseMap();
        }
    }
}

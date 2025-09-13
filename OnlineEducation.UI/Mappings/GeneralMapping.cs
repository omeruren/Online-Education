using AutoMapper;
using OnlineEducation.Entity.Entities;
using OnlineEducation.UI.DTOs.RoleDtos;

namespace OnlineEducation.UI.Mappings
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<AppRole, ResultRoleDto>().ReverseMap();
            CreateMap<AppRole, CreateRoleDto>().ReverseMap();
            CreateMap<AppRole, UpdateRoleDto>().ReverseMap();
        }
    }
}

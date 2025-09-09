using AutoMapper;
using OnlineEducation.DTO.DTOs.Banner;
using OnlineEducation.Entity.Entities;

namespace OnlineEducation.API.Mapping
{
    public class BannerMapping: Profile
    {
        public BannerMapping()
        {
            CreateMap<CreateBannerDto, Banner>().ReverseMap();
            CreateMap<UpdateBannerDto, Banner>().ReverseMap();
        }
    }
}

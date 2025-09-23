using OnlineEducation.DTO.DTOs.LoginDtos;
using OnlineEducation.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducation.Business.Abstract
{
    public interface IJwtService
    {
        Task<LoginResponseDto> CreateTokenAsync(AppUser user);
    }
}

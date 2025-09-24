using OnlineEducation.DTO.DTOs.TeacherSocialDtos;

namespace OnlineEducation.DTO.DTOs.UserDtos
{
    public class ResultUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Avatar { get; set; }
        public List<ResultTeacherSocialDto> TeacherSocials{ get; set; }
    }
}

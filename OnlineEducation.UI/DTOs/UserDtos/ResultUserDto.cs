using OnlineEducation.UI.DTOs.TeacherSocialDtos;

namespace OnlineEducation.UI.DTOs.UserDtos
{
    public class ResultUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Avatar { get; set; }
        public List<ResultTeacherSocialDto> TeacherSocials{ get; set; }
    }
}

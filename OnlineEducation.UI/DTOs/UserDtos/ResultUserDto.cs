using OnlineEducation.UI.DTOs.BlogDtos;
using OnlineEducation.UI.DTOs.CourseDtos;
using OnlineEducation.UI.DTOs.CourseRegisterDtos;
using OnlineEducation.UI.DTOs.TeacherSocialDtos;

namespace OnlineEducation.UI.DTOs.UserDtos
{
    public class ResultUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? Avatar { get; set; }
        public List<ResultTeacherSocialDto> TeacherSocials { get; set; }
        public List<ResultCourseDto> Courses { get; set; }
        public List<ResultCourseRegisterDto> CourseRegisters { get; set; }
        public List<ResultBlogDto> Blogs { get; set; }
    }
}

using OnlineEducation.UI.DTOs.CourseDtos;

namespace OnlineEducation.UI.DTOs.CourseVideoDtos
{
    public class ResultCourseVideoDto
    {
        public int CourseVideoId { get; set; }
        public int CourseId { get; set; }
        public ResultCourseDto Course { get; set; }
        public int VideoNumber { get; set; }
        public string VideoUrl { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducation.Entity.Entities
{
    public class CourseCategory
    {
        public int CourseCategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public bool IsShown { get; set; }

    }
}

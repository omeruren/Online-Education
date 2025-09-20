using OnlineEducation.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducation.DataAccess.Abstract
{
    public interface ICourseRepository : IRepository<Course>
    {
        void ShowOnHome(int id);
        void DontShowOnHome(int id);
        List<Course> GetAllCoursesWithCategories();
        List<Course> GetAllCoursesWithCategories(Expression<Func<Course, bool>> filter = null);
        List<Course> GetCoursesByTeacherId(int id);
    }
}

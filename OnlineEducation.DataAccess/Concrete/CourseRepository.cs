using Microsoft.EntityFrameworkCore;
using OnlineEducation.DataAccess.Abstract;
using OnlineEducation.DataAccess.Context;
using OnlineEducation.DataAccess.Repositories;
using OnlineEducation.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducation.DataAccess.Concrete
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(OnlineEducationContext context) : base(context)
        {
        }

        public void DontShowOnHome(int id)
        {
            var value = _context.Courses.Find(id);
            value.IsShown = false;
            _context.SaveChanges();
        }

        public List<Course> GetAllCoursesWithCategories()
        {
            return _context.Courses.Include(c => c.CourseCategory).Include(c => c.AppUser).ToList();
        }

        public List<Course> GetAllCoursesWithCategories(Expression<Func<Course, bool>> filter = null)
        {
            IQueryable<Course> values = _context.Courses.Include(c => c.CourseCategory).Include(c => c.AppUser).AsQueryable();
            if (filter != null)
            {

                values = values.Where(filter);
            }

            return values.ToList();
        }

        public List<Course> GetCoursesByTeacherId(int id)
        {
            return _context.Courses.Include(c => c.CourseCategory).Where(c => c.AppUserId == id).ToList();
        }

        public void ShowOnHome(int id)
        {
            var value = _context.Courses.Find(id);
            value.IsShown = true;
            _context.SaveChanges();
        }
    }
}

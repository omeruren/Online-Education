using OnlineEducation.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducation.Business.Abstract
{
    public interface ICourseCategoryService : IGenericService<CourseCategory>
    {
        void TShowOnHome(int id);
        void TDontShowOnHome(int id);
    }
}

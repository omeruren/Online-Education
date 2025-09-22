using Microsoft.EntityFrameworkCore;
using OnlineEducation.DataAccess.Abstract;
using OnlineEducation.DataAccess.Context;
using OnlineEducation.DataAccess.Repositories;
using OnlineEducation.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducation.DataAccess.Concrete
{
    public class BlogCategoryRepository : GenericRepository<BlogCategory>, IBlogCategoryRepository
    {
        public BlogCategoryRepository(OnlineEducationContext context) : base(context)
        {
        }

        public List<BlogCategory> GetCategoriesWithBlogs()
        {
            return _context.BlogCategories.Include(x => x.Blogs).ToList();
        }
    }
}

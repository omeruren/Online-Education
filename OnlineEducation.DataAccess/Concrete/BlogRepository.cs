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
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {

        public BlogRepository(OnlineEducationContext _context) : base(_context)
        {

        }

        public List<Blog> GetBlogsWithCategories()
        {
            return _context.Blogs.Include(b => b.BlogCategory).ToList();
        }

        public List<Blog> GetBlogsWithCategoriesByWriterId(int id)
        {
            return _context.Blogs.Include(b => b.BlogCategory).Where(b => b.WriterId == id).ToList();
        }
    }
}

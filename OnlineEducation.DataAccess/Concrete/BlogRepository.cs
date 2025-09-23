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

        public List<Blog> GetBlogsByCategoryId(int id)
        {
            return _context
                .Blogs
                .Include(x => x.BlogCategory)
                .Include(x => x.Writer)
                .Where(x => x.BlogCategoryId == id)
                .ToList(); // Eager Loading
        }

        public List<Blog> GetBlogsWithCategories()
        {
            return _context
                .Blogs
                .Include(b => b.BlogCategory)
                .Include(x => x.Writer)
                .ToList(); 
        }

        public List<Blog> GetBlogsWithCategoriesByWriterId(int id)
        {
            return _context
                .Blogs
                .Include(b => b.BlogCategory)
                .Where(b => b.WriterId == id)
                .ToList();
        }

        public Blog GetBlogWithCategory(int id)
        {
            return _context
                .Blogs
                .Include(x => x.BlogCategory)
                .Include(x => x.Writer)
                .ThenInclude(x => x.TeacherSocials)
                .FirstOrDefault(x => x.BlogId == id);
        }

        public List<Blog> GetLastFourBlogsWithCategories()
        {
            return _context
                .Blogs
                .Include(b => b.BlogCategory)
                .OrderByDescending(b => b.BlogId)
                .Take(4)
                .ToList();
        }
    }
}

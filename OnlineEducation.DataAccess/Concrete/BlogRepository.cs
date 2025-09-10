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
        private readonly OnlineEducationContext _onlineEducationContext;
        public BlogRepository(OnlineEducationContext _context) : base(_context)
        {
            _onlineEducationContext = _context;
        }

        public List<Blog> GetBlogsWithCategories()
        {
            return _onlineEducationContext.Blogs.Include(b => b.BlogCategory).ToList();
        }
    }
}

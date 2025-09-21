using OnlineEducation.Business.Abstract;
using OnlineEducation.DataAccess.Abstract;
using OnlineEducation.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducation.Business.Concrete
{
    public class BlogCategoryManager : GenericManager<BlogCategory>, IBlogCategoryService
    {
        private readonly IBlogCategoryRepository _blogCategory;
        public BlogCategoryManager(IRepository<BlogCategory> _repository, IBlogCategoryRepository blogCategory) : base(_repository)
        {
            _blogCategory = blogCategory;
        }

        public List<BlogCategory> TGetCategoriesWithBlogs()
        {
            return _blogCategory.GetCategoriesWithBlogs();
        }
    }
}

using OnlineEducation.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducation.Business.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {
        List<Blog> TGetBlogsWithCategories();
        List<Blog> TGetBlogsWithCategoriesByWriterId(int id);
    }
}

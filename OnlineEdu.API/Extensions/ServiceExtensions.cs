using OnlineEducation.Business.Abstract;
using OnlineEducation.Business.Concrete;
using OnlineEducation.DataAccess.Abstract;
using OnlineEducation.DataAccess.Concrete;
using OnlineEducation.DataAccess.Repositories;

namespace OnlineEducation.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServiceExtensions(this IServiceCollection services) {


            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IBlogService, BlogManager>();

            services.AddScoped<ICourseCategoryRepository, CourseCategoryRepository>();
            services.AddScoped<ICourseCategoryService, CourseCategoryManager>();

        }
    }
}

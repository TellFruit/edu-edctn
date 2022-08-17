using Microsoft.Extensions.DependencyInjection;
using Portal.Persistence_EF_Core.MappingProfiles;
using Portal.Persistence_EF_Core.Repositories;
using System.Configuration;
using System.Reflection;

namespace Portal.Persistence_EF_Core
{
    public static class DependencyInjection
    {
        public static void RegisterEntityFramework(IServiceCollection services)
        {
            services.AddAutoMapper(
                cfg =>
                {
                    cfg.AddProfile<UserEntityProfile>();
                    cfg.AddProfile<ArticleEntityProfile>();
                    cfg.AddProfile<BookEntityProfile>();
                    cfg.AddProfile<VideoEnityProfile>();
                    cfg.AddProfile<MaterialEntityProfile>();
                    cfg.AddProfile<CourseEntiyProfile>();
                },
            Assembly.GetExecutingAssembly());

            services.AddScoped<PortalContext>();

            services.AddScoped<IGenericRepository<UserDomain>, UserRepository>();
            services.AddScoped<IGenericRepository<ArticleDomain>, ArticleRepository>();
            services.AddScoped<IGenericRepository<BookDomain>, BookRepository>();
            services.AddScoped<IGenericRepository<VideoDomain>, VideoRepository>();
            services.AddScoped<IGenericRepository<CourseDomain>, CourseRepository>();
        }
    }
}

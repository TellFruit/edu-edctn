using Microsoft.Extensions.DependencyInjection;
using Portal.Application.Interfaces.OuterImpl;
using Portal.Domain.Entities;
using Portal.Persistence_EF_Core.MappingProfiles;
using Portal.Persistence_EF_Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

            services.Adds<PortalContext>();

            services.AddScoped<IGenericRepository<UserDomain>, UserRepository>();
            services.AddScoped<IGenericRepository<ArticleDomain>, ArticleRepository>();
            services.AddScoped<IGenericRepository<BookDomain>, BookRepository>();
            services.AddScoped<IGenericRepository<VideoDomain>, VideoRepository>();
            services.AddScoped<IGenericRepository<CourseDomain>, CourseRepository>();
        }
    }
}

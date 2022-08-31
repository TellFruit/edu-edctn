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
                    cfg.AddProfile<UserCourseEntityProfile>();
                },
            Assembly.GetExecutingAssembly());

            services.AddScoped<PortalContext>();

            services.AddScoped<IGenericRepository<UserDomain>, UserRepository>();
            services.AddScoped<IGenericRepository<ArticleDomain>, ArticleRepository>();
            services.AddScoped<IGenericRepository<BookDomain>, BookRepository>();
            services.AddScoped<IGenericRepository<VideoDomain>, VideoRepository>();
            services.AddScoped<IGenericRepository<CourseDomain>, CourseRepository>();
            services.AddScoped<IGenericRepository<PerkDomain>, PerkRepository>();
        }
    }
}

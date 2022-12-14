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
                    cfg.AddProfile<CourseEntityProfile>();
                    cfg.AddProfile<UserCourseEntityProfile>();
                    cfg.AddProfile<UserMaterialEntityProfile>();
                    cfg.AddProfile<UserPerkEntityProfile>();
                },
            Assembly.GetExecutingAssembly());

            services.AddScoped<IGenericRepository<UserDomain>, UserRepository>();
            services.AddScoped<IGenericRepository<ArticleDomain>, ArticleRepository>();
            services.AddScoped<IGenericRepository<BookDomain>, BookRepository>();
            services.AddScoped<IGenericRepository<VideoDomain>, VideoRepository>();
            services.AddScoped<IGenericRepository<CourseDomain>, CourseRepository>();
            services.AddScoped<IGenericRepository<PerkDomain>, PerkRepository>();
        }

        public static void RegisterDbContextXml(IServiceCollection services)
        {
            services.RegisterDbContext(
                System.Configuration.ConfigurationManager
                .ConnectionStrings["EducationalPortal"]
                .ConnectionString);
        }

        public static void RegisterDbContextJson(IServiceCollection services, IConfiguration config)
        {
            services.RegisterDbContext(config.GetConnectionString("Default"));
        }

        private static void RegisterDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<PortalContext>(options =>
                options.UseSqlServer(connectionString));
        }
    }
}

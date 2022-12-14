namespace Portal.Application
{
    public static class DependencyInjection
    {
        public static void RegisterApplication(IServiceCollection services)
        {
            services.AddAutoMapper(
                cfg =>
            {
                cfg.AddProfile<ArticleProfile>();
                cfg.AddProfile<BookProfile>();
                cfg.AddProfile<VideoProfile>();
                cfg.AddProfile<PerkProfile>();
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<CourseProfile>();
                cfg.AddProfile<MaterialProfile>();
            },
            Assembly.GetExecutingAssembly());

            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IVideoService, VideoService>();
            services.AddScoped<IPerkService, PerkService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICourseService, CourseService>();

            services.AddScoped<AbstractValidator<ArticleDTO>, ArticleValidator>();
            services.AddScoped<AbstractValidator<BookDTO>, BookValidator>();
            services.AddScoped<AbstractValidator<VideoDTO>, VideoValidator>();
            services.AddScoped<AbstractValidator<PerkDTO>, PerkValidator>();
            services.AddScoped<AbstractValidator<CourseDTO>, CourseValidator>();
            services.AddScoped<AbstractValidator<UserDTO>, UserValidator>();

            services.AddScoped<IConfigService, ConfigService>();

            services.AddScoped<IUserAuth, UserAuth>();

            services.AddScoped<IRuleUser, RuleUserService>();

            services.AddScoped<ISerialize, SimpleJsonService>();

            services.AddTransient<UserDTO>();
        }
    }
}

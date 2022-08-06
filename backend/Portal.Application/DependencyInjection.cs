namespace Portal.Application
{
    public static class DependencyInjection
    {
        public static void RegisterApplication(IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<ArticleProfile>();
                cfg.AddProfile<BookProfile>();
                cfg.AddProfile<VideoProfile>();
                cfg.AddProfile<PerkProfile>();
                cfg.AddProfile<UserProfile>();
            },
            Assembly.GetExecutingAssembly());

            services.AddScoped<ArticleService>();
            services.AddScoped<BookService>();
            services.AddScoped<VideoService>();
            services.AddScoped<PerkService>();
            services.AddScoped<UserService>();

            services.AddScoped<IUserAuth, UserAuth>();
        }
    }
}

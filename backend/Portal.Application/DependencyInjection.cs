﻿namespace Portal.Application
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
                cfg.AddProfile<MaterilProfile>();
            },
            Assembly.GetExecutingAssembly());

            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IVideoService, VideoService>();
            services.AddScoped<IPerkService, PerkService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICourseService, CourseService>();

            services.AddScoped<IConfigService, ConfigService>();

            services.AddSingleton<IUserAuth, UserAuth>();
        }
    }
}

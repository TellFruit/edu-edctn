var builder = WebApplication.CreateBuilder(args);

// Add services from used used layers
Portal.Application
     .DependencyInjection.RegisterApplication(builder.Services);

Portal.Persistence_EF_Core
    .DependencyInjection.RegisterEntityFramework(builder.Services);

Portal.Persistence_EF_Core
    .DependencyInjection.RegisterDbContextJson(builder.Services, builder.Configuration);

builder.Services.AddAutoMapper(
                cfg =>
                {
                    cfg.AddProfile<CourseArticleModelProfile>();
                    cfg.AddProfile<CourseBookModelProfile>();
                    cfg.AddProfile<CourseVideoModelProfile>();
                    cfg.AddProfile<CoursePerkProfile>();
                    cfg.AddProfile<CourseViewModelProfile>();
                },
                Assembly.GetExecutingAssembly());

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
       .AddCookie(options =>
       {
           options.LoginPath = new PathString("/Auth/Login");
           options.Cookie.Name = "my_app_auth_cookie";
       });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
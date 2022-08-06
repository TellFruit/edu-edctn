using Portal.Persistence_Json.Services;

namespace Portal.Persistence_Json
{
    public static class DependencyInjection
    {
        public static void RegisterPersistenceJson(IServiceCollection services)
        {
            services.AddScoped<ISerializationService, NewtonJsonService>();
            services.AddScoped<IFileIoService, FileIoService>();

            services
                .AddScoped(typeof(IGenericRepository<>),
                           typeof(JsonGenericRepository<>));
        }
    }
}

namespace Portal.Persistence_Json
{
    public static class DependencyInjection
    {
        public static void RegisterPersistenceJson(IServiceCollection services)
        {
            services
                .AddScoped(typeof(IGenericRepository<>),
                           typeof(JsonGenericRepository<>));
        }
    }
}

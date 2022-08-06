namespace Portal.UI_Console
{
    [ExcludeFromCodeCoverage]
    static class Program
    {
        private static IServiceProvider _root;
        public static IServiceProvider Root => _root;

        private static IServiceProvider CompositionRoot()
        {
            var services = new ServiceCollection();

            services.AddSingleton<ConsoleApp>();

            Portal.Application
                .DependencyInjection.RegisterApplication(services);
            Portal.Persistence_Json
                .DependencyInjection.RegisterPersistenceJson(services);

            return services.BuildServiceProvider();
        }

        public static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            _root = CompositionRoot();

            Root.GetService<ConsoleApp>().Run();
        }
    }
}
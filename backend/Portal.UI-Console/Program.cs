﻿namespace Portal.UI_Console
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

            services.AddScoped<IChooseCommand, ChooseInitCommand>();
            services.AddScoped<ICommandManager, CommandManager>();

            // as the only place it is passes through DI is CommandManager
            // and in CommandManager it is required to use exactly that parser
            services.AddScoped<IParseInput, ParseInitPrompt>();

            Portal.Application
                .DependencyInjection.RegisterApplication(services);
            Portal.Persistence_Json
                .DependencyInjection.RegisterPersistenceJson(services);

            return services.BuildServiceProvider();
        }

        public static Task Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            _root = CompositionRoot();

            Root.GetService<ConsoleApp>()?.Start();

            return Task.CompletedTask;
        }
    }
}
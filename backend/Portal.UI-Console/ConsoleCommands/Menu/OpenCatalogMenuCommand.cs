namespace Portal.UI_Console.ConsoleCommands.Menu
{
    internal class OpenCatalogMenuCommand : IConsoleCommand
    {
        private readonly IConfigService _configService;

        public OpenCatalogMenuCommand(IConfigService configService)
        {
            _configService = configService;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            var basicParser = Program.Root.GetRequiredService<IParseInput>();
            var chooseCommand = new ChooseCatalogCommand(_configService);

            var launchCommand = new LaunchManagerCommand(chooseCommand, basicParser);

            Console.WriteLine("Catalog menu opened!");

            await launchCommand.Run();

            return true;
        }
    }
}

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
            var basicParser = Program.Root.GetService<IParseInput>();
            var chooseCommad = new ChooseCatalogCommand(_configService);

            var commandManager = new CommandManager(basicParser, chooseCommad);

            await commandManager.InitCommandFlow();

            return true;
        }
    }
}

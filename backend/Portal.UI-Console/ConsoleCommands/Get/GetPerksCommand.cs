namespace Portal.UI_Console.ConsoleCommands.Get
{
    internal class GetPerkCommand : IConsoleCommand
    {
        private readonly IPerkService _perkService;

        public GetPerkCommand(IPerkService perkService)
        {
            _perkService = perkService;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            var all = await _perkService.GetAll();

            var configService = Program.Root.GetService<IConfigService>();

            IConsoleCommand paginate = new PaginateCommand<PerkDTO>(configService, all);

            await paginate.Run();

            return true;
        }
    }
}

namespace Portal.UI_Console.ConsoleCommands.Get
{
    internal class GetPerksCommand : IConsoleCommand
    {
        private readonly IPerkService _perkService;

        public GetPerksCommand(IPerkService perkService)
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

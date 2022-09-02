namespace Portal.UI_Console.ConsoleCommands.Modify.Skills
{
    internal class DeletePerkCommand : IConsoleCommand
    {
        private readonly IPerkService _perkService;

        public DeletePerkCommand(IPerkService perkService)
        {
            _perkService = perkService;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            var userAuth = Program.Root.GetRequiredService<IUserAuth>();

            var auth = new AuthorizeCommand(userAuth);
            if (await auth.Run() is false)
            {
                Console.WriteLine("Operation suspended!");
                return true;
            }

            await _perkService.Delete(int.Parse(parameters[0]));
            Console.WriteLine("Success! Perk deleted");

            return true;
        }
    }
}

namespace Portal.UI_Console.ConsoleCommands.Menu
{
    internal class OpenProfileMenuCommand : IConsoleCommand
    {
        private readonly IUserService _userService;
        private readonly IUserAuth _userAuth;

        public OpenProfileMenuCommand(IUserService userService, IUserAuth userAuth = null)
        {
            _userService = userService;
            _userAuth = userAuth;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            var auth = new AuthorizeCommand(_userAuth);
            if (await auth.Run() is false)
            {
                Console.WriteLine("Operation suspended!");
                return true;
            }

            var wantedUser = await _userService.GetById(_userAuth.LoggedId);

            var chooseCommand = new ChooseProfileCommand(wantedUser);
            var basicParser = Program.Root.GetService<IParseInput>();

            var launchCommand = new LaunchManagerCommand(chooseCommand, basicParser);

            Console.WriteLine("Catalog menu opened!");

            await launchCommand.Run();

            return true;
        }
    }
}

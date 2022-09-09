namespace Portal.UI_Console.ConsoleCommands.Menu
{
    internal class OpenProfileMenuCommand : IConsoleCommand
    {
        private readonly IUserService _userService;
        private readonly UserDTO _userDTO;


        public OpenProfileMenuCommand(IUserService userService, UserDTO userDTO)
        {
            _userService = userService;
            _userDTO = userDTO;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            if (await _userDTO.CallAuthCommand() is false)
            {
                Console.WriteLine("Operation suspended!");
                return true;
            }

            var wantedUser = await _userService.GetById(_userDTO.Id);

            var chooseCommand = new ChooseProfileCommand(wantedUser);
            var basicParser = Program.Root.GetRequiredService<IParseInput>();

            var launchCommand = new LaunchManagerCommand(chooseCommand, basicParser);

            Console.WriteLine("Profile menu opened!");

            await launchCommand.Run();

            return true;
        }
    }
}

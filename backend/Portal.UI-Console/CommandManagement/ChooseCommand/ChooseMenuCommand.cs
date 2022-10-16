namespace Portal.UI_Console.CommandManagement.ChooseCommand
{
    internal class ChooseMenuCommand : IChooseCommand
    {
        private readonly UserDTO _userDTO;

        public ChooseMenuCommand(UserDTO userDTO)
        {
            _userDTO = userDTO;
        }

        public IConsoleCommand Choose(out IParseInput? parser, string commandName)
        {
            parser = null;

            switch (commandName)
            {
                case "open-catalog":
                    {
                        var configService = Program.Root.GetRequiredService<IConfigService>();

                        return new OpenCatalogMenuCommand(configService, _userDTO);
                    }

                case "open-profile":
                    {
                        var userService = Program.Root.GetRequiredService<IUserService>();

                        return new OpenProfileMenuCommand(userService, _userDTO);
                    }

                case "exit":
                    {
                        return new TerminateCommand();
                    }

                default:
                    break;
            }

            throw new InvalidOperationException(nameof(commandName));
        }
    }
}

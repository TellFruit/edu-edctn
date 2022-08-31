namespace Portal.UI_Console.CommandManagement.ChooseCommand
{
    internal class ChooseMenuCommand : IChooseCommand
    {
        public IConsoleCommand Choose(out IParseInput? parser, string commandName)
        {
            parser = null;

            switch (commandName)
            {
                case "open-catalog":
                    {
                        var configService = Program.Root.GetService<IConfigService>();

                        return new OpenCatalogMenuCommand(configService);
                    }

                case "open-profile":
                    {
                        var userAuth = Program.Root.GetService<IUserAuth>();

                        var userService = Program.Root.GetService<IUserService>();

                        return new OpenProfileMenuCommand(userService, userAuth);
                    }

                default:
                    break;
            }

            throw new InvalidOperationException(nameof(commandName));
        }
    }
}

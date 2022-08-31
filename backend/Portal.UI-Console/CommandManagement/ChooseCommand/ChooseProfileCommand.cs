namespace Portal.UI_Console.CommandManagement.ChooseCommand
{
    internal class ChooseProfileCommand : IChooseCommand
    {
        private readonly UserDTO _userDTO;

        public ChooseProfileCommand(UserDTO userDTO)
        {
            _userDTO = userDTO;
        }

        public IConsoleCommand Choose(out IParseInput? parser, string commandName)
        {
            parser = null;

            switch(commandName)
            {
                default:
                    break;
            }

            throw new InvalidOperationException(nameof(commandName));
        }
    }
}

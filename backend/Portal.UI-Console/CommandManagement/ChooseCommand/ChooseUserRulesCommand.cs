namespace Portal.UI_Console.CommandManagement.ChooseCommand
{
    internal class ChooseUserRulesCommand : IChooseCommand
    {
        private readonly UserDTO _userDTO;

        public ChooseUserRulesCommand(UserDTO userDTO)
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

namespace Portal.UI_Console.ConsoleCommands.Auth
{
    internal class LogoutCommand : IConsoleCommand
    {
        private readonly UserDTO _userDTO;
        private readonly bool _returnValue;

        public LogoutCommand(bool returnValue, UserDTO userDTO)
        {
            _returnValue = returnValue;
            _userDTO = userDTO;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            if (_userDTO.Id.Equals(default) is false)
            {
                _userDTO.Id = default;
                Console.WriteLine("Success! You've just logged out.");
            }
            else
            {
                Console.WriteLine("Failure! You are alredy not logged...");
            }

            return _returnValue;
        }
    }
}

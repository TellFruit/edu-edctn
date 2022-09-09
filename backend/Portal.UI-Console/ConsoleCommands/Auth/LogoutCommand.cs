namespace Portal.UI_Console.ConsoleCommands.Auth
{
    internal class LogoutCommand : IConsoleCommand
    {
        private readonly IUserAuth _userAuth;
        private readonly UserDTO _userDTO;
        private readonly bool _returnValue;

        public LogoutCommand(IUserAuth userAuth, bool returnValue, UserDTO userDTO)
        {
            _userAuth = userAuth;
            _returnValue = returnValue;
            _userDTO = userDTO;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            if (_userAuth.Logout(_userDTO.Id))
            {
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

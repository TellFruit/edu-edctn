namespace Portal.UI_Console.ConsoleCommands.Auth
{
    internal class LogoutCommand : IConsoleCommand
    {
        private readonly IUserAuth _userAuth;

        public LogoutCommand(IUserAuth userAuth)
        {
            _userAuth = userAuth;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            if (await _userAuth.Logout())
            {
                Console.WriteLine("Success! You've just logged out.");
            }
            else
            {
                Console.WriteLine("Failure! You are alredy not logged...");
            }

            return true;
        }
    }
}

namespace Portal.UI_Console.ConsoleCommands.Auth
{
    internal class AuthorizeCommand : IConsoleCommand
    {
        private readonly IUserAuth _userAuth;

        public AuthorizeCommand(IUserAuth userAuth)
        {
            _userAuth = userAuth;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            if (_userAuth.IsAuthenticated)
            {
                return true;
            }

            string input = "";
            do
            {
                Console.WriteLine("Write 'login' or 'register'. To suspend - write 'return'");
                input = Console.ReadLine();

                if (input.Equals("return"))
                {
                    break;
                }

                if (input.Equals("login"))
                {
                    var login = new LoginCommand(_userAuth);
                    await login.Run();
                }

                if (input.Equals("register"))
                {
                    var register = new RegisterCommand(_userAuth);
                    await register.Run();
                }

                if (_userAuth.IsAuthenticated)
                {
                    break;
                }
            }
            while (true);

            return _userAuth.IsAuthenticated;
        }
    }
}

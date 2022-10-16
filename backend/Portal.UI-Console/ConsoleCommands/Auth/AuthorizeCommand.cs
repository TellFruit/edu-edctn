namespace Portal.UI_Console.ConsoleCommands.Auth
{
    internal class AuthorizeCommand : IConsoleCommand
    {
        private readonly IUserAuth _userAuth;
        private readonly UserDTO _userDTO;

        public AuthorizeCommand(IUserAuth userAuth, UserDTO userDTO)
        {
            _userAuth = userAuth;
            _userDTO = userDTO;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            if (await _userAuth.IsAuthorized(_userDTO.Id))
            {
                return true;
            }

            string input = string.Empty;
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
                    var login = new LoginCommand(_userAuth, _userDTO);
                    await login.Run();
                }

                if (input.Equals("register"))
                {
                    var register = new RegisterCommand(_userAuth, _userDTO);
                    await register.Run();
                }

                if (await _userAuth.IsAuthorized(_userDTO.Id))
                { 
                    break;
                }
            }
            while (true);

            return await _userAuth.IsAuthorized(_userDTO.Id);
        }
    }
}

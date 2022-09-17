namespace Portal.UI_Console.ConsoleCommands.Auth
{
    internal class RegisterCommand : IConsoleCommand
    {
        private readonly IUserAuth _userAuth;
        private readonly UserDTO _userDTO;

        public RegisterCommand(IUserAuth userAuth, UserDTO userDTO)
        {
            _userAuth = userAuth;
            _userDTO = userDTO;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            bool result = false;

            string email = string.Empty;
            string password = string.Empty;

            do
            {
                Console.WriteLine("To suspend the operation write \'return\': ");

                Console.WriteLine("Enter your email: ");
                email = Console.ReadLine();

                if (email.Equals("return"))
                {
                    break;
                }

                Console.WriteLine("Enter your password: ");
                password = Console.ReadLine();

                if (password.Equals("return"))
                {
                    break;
                }

                _userDTO.Id = await _userAuth.Register(email, password);

                result = await _userAuth.IsAuthorized(_userDTO.Id);

                if (result is false)
                {
                    Console.WriteLine("Email is already taken.");
                    continue;
                }

                _userDTO.Email = email;
                _userDTO.Password = password;

                return result;
            }
            while (true);

            return result;
        }
    }
}

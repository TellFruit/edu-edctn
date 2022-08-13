namespace Portal.UI_Console.ConsoleCommands.Auth
{
    internal class LoginCommand : IConsoleCommand
    {
        private readonly IUserAuth _userAuth;

        public LoginCommand(IUserAuth userAuth)
        {
            _userAuth = userAuth;
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

                result = await _userAuth.Login(email, password);

                if (result is false)
                {
                    Console.WriteLine("Email or password is incorrect.");
                    continue;
                }

                return result;
            }
            while (true);

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            string email = "";
            string password = "";

            do
            {
                Console.WriteLine("To suspend the operation write \'return\': ");

                Console.WriteLine("Enter your email: ");
                email = Console.ReadLine(); 
                
                Console.WriteLine("Enter your password: ");
                password = Console.ReadLine();

                if (email.Equals("return") || password.Equals("return"))
                {
                    break;
                }

                result = await _userAuth.Login(email, password);

                if (result is false)
                {
                    Console.WriteLine("Email or password is incorrect.");
                }
            }
            while (true);

            return false;
        }
    }
}

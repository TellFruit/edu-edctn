using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.Write("Success! You've just logged out.");
            }
            else
            {
                Console.Write("Failure! You are alredy not logged...");
            }

            return true;
        }
    }
}

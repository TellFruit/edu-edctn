using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            do
            {

            }
            while (true);

            return true;
        }
    }
}

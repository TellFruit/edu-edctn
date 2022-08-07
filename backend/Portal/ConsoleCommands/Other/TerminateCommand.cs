using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.UI_Console.ConsoleCommands.Other
{
    internal class TerminateCommand : IConsoleCommand
    {
        public async Task<bool> Output(params string[] parameters)
        {
            Environment.Exit(0);

            return false;
        }
    }
}

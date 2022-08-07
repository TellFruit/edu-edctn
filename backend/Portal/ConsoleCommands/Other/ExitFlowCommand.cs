using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.UI_Console.ConsoleCommands.Other
{
    internal class ExitFlowCommand : IConsoleCommand
    {
        public async Task<bool> Output(params string[] parameters)
        {
            Console.WriteLine("Current flow is finished!");

            return false;
        }
    }
}

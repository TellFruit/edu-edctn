using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.UI_Console.ConsoleCommands.Modify.Skills
{
    internal class DeleteSkillCommand : IConsoleCommand
    {
        private readonly IPerkService _perkService;

        public DeleteSkillCommand(IPerkService perkService)
        {
            _perkService = perkService;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            var userAuth = Program.Root.GetService<IUserAuth>();

            var auth = new AuthorizeCommand(userAuth);
            if (await auth.Run() is false)
            {
                Console.WriteLine("Operation suspended!");
                return true;
            }

            await _perkService.Delete(int.Parse(parameters[0]));
            Console.WriteLine("Success! Perk deleted");

            return true;
        }
    }
}

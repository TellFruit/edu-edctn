using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.UI_Console.ConsoleCommands.Modify.Skills
{
    internal class UpdatePerkCommand : IConsoleCommand
    {
        private readonly IPerkService _perkService;

        public UpdatePerkCommand(IPerkService perkService)
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

            /* Examples of correct input:
             * 1 - Tilte
             */

            var toCreate = new PerkDTO()
            {
                Id = int.Parse(parameters[0]),
                Name = parameters[1],
            };

            await _perkService.Update(toCreate);
            Console.WriteLine("Success! Perk updated.");

            return true;
        }
    }
}

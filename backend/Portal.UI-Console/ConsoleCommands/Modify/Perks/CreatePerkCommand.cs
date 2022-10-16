namespace Portal.UI_Console.ConsoleCommands.Modify.Skills
{
    internal class CreatePerkCommand : IConsoleCommand
    {
        private readonly IPerkService _perkService;
        private readonly UserDTO _userDTO;

        public CreatePerkCommand(IPerkService perkService, UserDTO userDTO)
        {
            _perkService = perkService;
            _userDTO = userDTO;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            if (await _userDTO.CallAuthCommand() is false)
            {
                Console.WriteLine("Operation suspended!");
                return true;
            }

            /* Examples of correct input:
             * Tilte
             */

            var toCreate = new PerkDTO()
            {
                Name = parameters[0],
            };

            await _perkService.Create(toCreate);
            Console.WriteLine("Success! Perk created");

            return true;
        }
    }
}

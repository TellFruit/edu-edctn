namespace Portal.UI_Console.ConsoleCommands.Modify.Skills
{
    internal class UpdatePerkCommand : IConsoleCommand
    {
        private readonly IPerkService _perkService;
        private readonly UserDTO _userDTO;

        public UpdatePerkCommand(IPerkService perkService, UserDTO userDTO)
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

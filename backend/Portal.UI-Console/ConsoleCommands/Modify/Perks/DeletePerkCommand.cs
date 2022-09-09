namespace Portal.UI_Console.ConsoleCommands.Modify.Skills
{
    internal class DeletePerkCommand : IConsoleCommand
    {
        private readonly IPerkService _perkService;
        private readonly UserDTO _userDTO;

        public DeletePerkCommand(IPerkService perkService, UserDTO userDTO)
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

            await _perkService.Delete(int.Parse(parameters[0]));
            Console.WriteLine("Success! Perk deleted");

            return true;
        }
    }
}

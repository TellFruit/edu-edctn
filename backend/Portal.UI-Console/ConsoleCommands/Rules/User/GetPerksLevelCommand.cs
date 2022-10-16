namespace Portal.UI_Console.ConsoleCommands.Rules.User
{
    internal class GetPerksLevelCommand : IConsoleCommand
    {
        private UserDTO _userDTO;

        public GetPerksLevelCommand(UserDTO userDTO)
        {
            _userDTO = userDTO;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            Console.WriteLine("All perks you got:");
            foreach (var perk in _userDTO.PerkLevel)
            {
                Console.WriteLine(perk);
            }

            return true;
        }
    }
}

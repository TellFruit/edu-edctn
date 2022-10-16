namespace Portal.UI_Console.ConsoleCommands.Rules.User
{
    internal class GetLearnedMaterialsCommand : IConsoleCommand
    {
        private UserDTO _userDTO;

        public GetLearnedMaterialsCommand(UserDTO userDTO)
        {
            _userDTO = userDTO;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            Console.WriteLine("All materials you learned:");
            foreach (var learned in _userDTO.MaterialLearned)
            {
                Console.WriteLine(learned.Material);
            }

            return true;
        }
    }
}

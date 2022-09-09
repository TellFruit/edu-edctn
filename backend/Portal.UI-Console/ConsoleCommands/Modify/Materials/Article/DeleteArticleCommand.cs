namespace Portal.UI_Console.ConsoleCommands.Modify.Materials.Article
{
    internal class DeleteArticleCommand : IConsoleCommand
    {
        private readonly IArticleService _articleService;
        private readonly UserDTO _userDTO;

        public DeleteArticleCommand(IArticleService articleService, UserDTO userDTO)
        {
            _articleService = articleService;
            _userDTO = userDTO;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            if (await _userDTO.CallAuthCommand() is false)
            {
                Console.WriteLine("Operation suspended!");
                return true;
            }

            await _articleService.Delete(int.Parse(parameters[0]));
            Console.WriteLine("Success! Article deleted");

            return true;
        }
    }
}

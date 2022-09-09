namespace Portal.UI_Console.ConsoleCommands.Modify.Materials.Article
{
    internal class CreateArticleCommand : IConsoleCommand
    {
        private readonly IArticleService _articleService;
        private readonly UserDTO _userDTO;

        public CreateArticleCommand(IArticleService articleService, UserDTO userDTO)
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

            /* Examples of correct input:
             * Tilte - https://regex101.com/ (11.12.2002)
             * Tilte - https://regex101.com/ (11/12/2002)
             * Tilte - https://regex101.com/ (2002)
             */

            var toCreate = new ArticleDTO() 
            {
                Title = parameters[0],
                Url = parameters[1],
                Published = DateTime.Parse(parameters[2])
            };

            await _articleService.Create(toCreate);
            Console.WriteLine("Success! Article created");

            return true;
        }
    }
}

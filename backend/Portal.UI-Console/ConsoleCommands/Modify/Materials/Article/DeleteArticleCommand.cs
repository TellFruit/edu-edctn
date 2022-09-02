namespace Portal.UI_Console.ConsoleCommands.Modify.Materials.Article
{
    internal class DeleteArticleCommand : IConsoleCommand
    {
        private readonly IArticleService _articleService;

        public DeleteArticleCommand(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            var userAuth = Program.Root.GetRequiredService<IUserAuth>();

            var auth = new AuthorizeCommand(userAuth);
            if (await auth.Run() is false)
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

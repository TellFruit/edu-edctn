namespace Portal.UI_Console.ConsoleCommands.Get
{
    internal class GetArticlesCommand : IConsoleCommand
    {
        private readonly IArticleService _articleService;

        public GetArticlesCommand(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            var all = await _articleService.GetAll();

            var configService = Program.Root.GetService<IConfigService>();

            IConsoleCommand paginate = new PaginateCommand<ArticleDTO>(configService, all);

            await paginate.Run();

            return true;
        }
    }
}

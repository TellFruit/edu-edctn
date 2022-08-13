namespace Portal.UI_Console.ConsoleCommands.Modify.Course.Add
{
    internal class AddArticleCommand : IConsoleCommand
    {
        private readonly IArticleService _article;

        private readonly CourseDTO _courseDTO;

        public AddArticleCommand(IArticleService articleService, CourseDTO courseDTO)
        {
            _article = articleService;
            _courseDTO = courseDTO;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            var configService = Program.Root.GetService<IConfigService>();

            var articles = await _article.GetAll();

            var viewCommand = new PaginateCommand<ArticleDTO>(configService, articles);

            Console.WriteLine("Take a look and write \'return\' to proceed and choose");
            await viewCommand.Run();

            int wantedId = 0;
            string input = string.Empty;
            do
            {
                ICollection<int> present = _courseDTO.Materials
                .Where(x => x as ArticleDTO is not null)
                .Select(x => x.Id).ToList();

                Console.WriteLine("Write id of wanted article or \'return\' to stop: ");

                input = Console.ReadLine();

                if (input.Equals("return"))
                {
                    return true;
                }

                try { wantedId = int.Parse(input); }
                catch { if (!input.Equals(string.Empty)) { input = string.Empty; continue; } }

                if (present.Contains(wantedId))
                {
                    Console.WriteLine("Already included!");
                    continue;
                }

                var wantedArticle = await _article.GetById(wantedId);

                if (wantedArticle is null)
                {
                    Console.WriteLine("Not found");
                    continue;
                }

                _courseDTO.Materials.Add(wantedArticle);
            }
            while (true);
        }
    }
}

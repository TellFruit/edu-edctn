using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.UI_Console.ConsoleCommands.Modify.Course
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
            string input = "";
            do
            {
                Console.WriteLine("Write id of wanted article or \'return\' to stop: ");

                input = Console.ReadLine();

                if (input.Equals("return"))
                {
                    break;
                }

                try { wantedId = int.Parse(input); }
                catch { if (!input.Equals("")) { input = ""; continue; } }

                break;
            }
            while (true);

            var wantedArticle = await _article.GetById(wantedId);

            _courseDTO.Materials.Add(wantedArticle);

            return true;
        }
    }
}

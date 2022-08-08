using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.UI_Console.ConsoleCommands.Get
{
    internal class GetArticlesCommand
    {
        private readonly IArticleService articleService;

        public GetArticlesCommand(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            var all = await articleService.GetAll();

            var configService = Program.Root.GetService<IConfigService>();

            IConsoleCommand paginate = new PaginateCommand<ArticleDTO>(configService, all);

            await paginate.Run();

            return true;
        }
    }
}

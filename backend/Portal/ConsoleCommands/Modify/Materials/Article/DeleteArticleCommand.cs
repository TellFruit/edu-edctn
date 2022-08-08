using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            await _articleService.Delete(int.Parse(parameters[0]));
            Console.WriteLine("Success! Article deleted");

            return true;
        }
    }
}

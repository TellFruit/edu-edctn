using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.UI_Console.ConsoleCommands.Modify.Materials.Article
{
    internal class UpdateArticleCommand : IConsoleCommand
    {
        private readonly IArticleService _articleService;

        public UpdateArticleCommand(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            var userAuth = Program.Root.GetService<IUserAuth>();

            var auth = new AuthorizeCommand(userAuth);
            if (await auth.Run() is false)
            {
                Console.WriteLine("Operation suspended!");
                return true;
            }

            /* Examples of correct input:
             * 1 - Tilte - https://regex101.com/ (11.12.2002)
             * 2 - Tilte - https://regex101.com/ (11/12/2002)
             * 3 - Tilte - https://regex101.com/ (2002)
             */

            var toUpdate = new ArticleDTO()
            {
                Id = int.Parse(parameters[0]),
                Title = parameters[1],
                Url = parameters[2],
                Published = DateTime.Parse(parameters[3])
            };

            await _articleService.Update(toUpdate);
            Console.WriteLine("Success! Article updated");

            return true;
        }
    }
}

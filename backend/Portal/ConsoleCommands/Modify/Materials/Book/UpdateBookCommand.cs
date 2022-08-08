using Portal.UI_Console.Parsers.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.UI_Console.ConsoleCommands.Modify.Materials.Book
{
    internal class UpdateBookCommand : IConsoleCommand
    {
        private readonly IBookService _bookService;

        public UpdateBookCommand(IBookService bookService)
        {
            _bookService = bookService;
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
             * Е. Таненбаум – Сучасні операційні системи, 1365 (12.05.2013).pdf
             * Е. Таненбаум, І. Амамбаум – Сучасні операційні системи, 1365 (12.05.2013).pdf
             */

            var toCreate = new BookDTO()
            {
                Id = int.Parse(parameters[0]),
                Authors = parameters[1].Split(", ").ToList(),
                Title = parameters[2],
                PageCount = int.Parse(parameters[3]),
                Published = new ParseDateTime().Parse(parameters[4]),
                Format = parameters[5],
            };

            await _bookService.Update(toCreate);
            Console.WriteLine("Success! Book updated");

            return true;
        }
    }
}

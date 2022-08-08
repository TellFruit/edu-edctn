using Portal.UI_Console.Parsers.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.UI_Console.ConsoleCommands.Modify.Materials.Book
{
    internal class CreateBookCommand : IConsoleCommand
    {
        private readonly IBookService _bookService;

        public CreateBookCommand(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            /* Examples of correct input:
             * Е. Таненбаум – Сучасні операційні системи, 1365 (12.05.2013).pdf
             * Е. Таненбаум, І. Амамбаум – Сучасні операційні системи, 1365 (12.05.2013).pdf
             */

            var toCreate = new BookDTO()
            {
                Authors = parameters[0].Split(", ").ToList(),
                Title = parameters[1],
                PageCount = int.Parse(parameters[2]),
                Published = new ParseDateTime().Parse(parameters[3]),
                Format = parameters[4],
            };

            await _bookService.Create(toCreate);
            Console.WriteLine("Success! Book created");

            return true;
        }
    }
}

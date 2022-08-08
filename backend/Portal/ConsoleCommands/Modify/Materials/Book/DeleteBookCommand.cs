using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.UI_Console.ConsoleCommands.Modify.Materials.Book
{
    internal class DeleteBookCommand : IConsoleCommand
    {
        private readonly IBookService _bookService;

        public DeleteBookCommand(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            await _bookService.Delete(int.Parse(parameters[0]));
            Console.WriteLine("Success! Book deleted");

            return true;
        }
    }
}

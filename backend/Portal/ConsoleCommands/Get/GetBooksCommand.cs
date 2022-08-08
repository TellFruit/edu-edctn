using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.UI_Console.ConsoleCommands.Get
{
    internal class GetBooksCommand : IConsoleCommand
    {
        private readonly IBookService _bookService;

        public GetBooksCommand(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            var all = await _bookService.GetAll();

            var configService = Program.Root.GetService<IConfigService>();

            IConsoleCommand paginate = new PaginateCommand<BookDTO>(configService, all);

            await paginate.Run();

            return true;
        }
    }
}

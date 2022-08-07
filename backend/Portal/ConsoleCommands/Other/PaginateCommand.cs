using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.UI_Console.ConsoleCommands.Other
{
    internal class PaginateCommand<T> : IConsoleCommand
    {
        private ICollection<T> _collection;

        public PaginateCommand(ICollection<T> collection)
        {
            _collection = collection;
        }

        public async Task Output(params string[] parameters)
        {
            string input = "";

            int page = 1;
            int pageSize = 3;

            do
            {
                if (input.Equals("return"))
                {
                    break;
                }

                try { page = int.Parse(input); }
                catch { if (!input.Equals("")) { input = ""; continue; } }

                Console.WriteLine($"Page {page}:");

                ICollection<T> paginated = _collection.GetPaginatedPage(page, pageSize);

                foreach (T item in paginated)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("Next page or \'return\': ");
                input = Console.ReadLine();
            }
            while (true);
        }
    }
}

namespace Portal.UI_Console.ConsoleCommands.Other
{
    internal class PaginateCommand<T> : IConsoleCommand
    {
        private readonly IConfigService _config;
        private ICollection<T> _collection;

        public PaginateCommand(IConfigService config, ICollection<T> collection)
        {
            _collection = collection;
            _config = config;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            string input = "";

            int page = 1;
            int pageSize = int.Parse(_config.GetSetting("PaginatedPageSize"));

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

            return true;
        }
    }
}

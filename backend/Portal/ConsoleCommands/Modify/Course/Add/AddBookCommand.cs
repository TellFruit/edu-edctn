namespace Portal.UI_Console.ConsoleCommands.Modify.Course.Add
{
    internal class AddBookCommand : IConsoleCommand
    {
        private readonly IBookService _book;

        private readonly CourseDTO _courseDTO;

        public AddBookCommand(IBookService bookService, CourseDTO courseDTO)
        {
            _book = bookService;
            _courseDTO = courseDTO;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            var configService = Program.Root.GetService<IConfigService>();

            var books = await _book.GetAll();

            var viewCommand = new PaginateCommand<BookDTO>(configService, books);

            Console.WriteLine("Take a look and write \'return\' to proceed and choose");
            await viewCommand.Run();

            ICollection<int> marked = new List<int>();
            int wantedId = 0;
            string input = "";
            do
            {
                Console.WriteLine("Write id of wanted book or \'return\' to stop: ");

                input = Console.ReadLine();

                if (input.Equals("return"))
                {
                    return true;
                }

                try { wantedId = int.Parse(input); }
                catch { if (!input.Equals("")) { input = ""; continue; } }

                if (marked.Contains(wantedId))
                {
                    Console.WriteLine("Already included!");
                    continue;
                }

                var wantedArticle = await _book.GetById(wantedId);

                _courseDTO.Materials.Add(wantedArticle);

                marked.Add(wantedId);
            }
            while (true);
        }
    }
}

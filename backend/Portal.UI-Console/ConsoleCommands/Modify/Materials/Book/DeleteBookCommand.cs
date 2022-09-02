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
            var userAuth = Program.Root.GetRequiredService<IUserAuth>();

            var auth = new AuthorizeCommand(userAuth);
            if (await auth.Run() is false)
            {
                Console.WriteLine("Operation suspended!");
                return true;
            }

            await _bookService.Delete(int.Parse(parameters[0]));
            Console.WriteLine("Success! Book deleted");

            return true;
        }
    }
}

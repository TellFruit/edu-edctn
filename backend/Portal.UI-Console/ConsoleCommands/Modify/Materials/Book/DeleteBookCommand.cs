namespace Portal.UI_Console.ConsoleCommands.Modify.Materials.Book
{
    internal class DeleteBookCommand : IConsoleCommand
    {
        private readonly IBookService _bookService;
        private readonly UserDTO _userDTO;

        public DeleteBookCommand(IBookService bookService, UserDTO userDTO)
        {
            _bookService = bookService;
            _userDTO = userDTO;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            if (await _userDTO.CallAuthCommand() is false)
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

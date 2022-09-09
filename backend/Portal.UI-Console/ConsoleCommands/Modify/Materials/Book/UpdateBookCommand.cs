using Portal.UI_Console.Parsers.Values;

namespace Portal.UI_Console.ConsoleCommands.Modify.Materials.Book
{
    internal class UpdateBookCommand : IConsoleCommand
    {
        private readonly IBookService _bookService;
        private readonly UserDTO _userDTO;

        public UpdateBookCommand(IBookService bookService, UserDTO userDTO)
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

            /* Examples of correct input:
             * Е. Таненбаум – Сучасні операційні системи, 1365 (12.05.2013).pdf
             * Е. Таненбаум, І. Амамбаум – Сучасні операційні системи, 1365 (12.05.2013).pdf
             */

            var toUpdate = new BookDTO()
            {
                Id = int.Parse(parameters[0]),
                Authors = parameters[1].Split(", ").ToList(),
                Title = parameters[2],
                PageCount = int.Parse(parameters[3]),
                Published = new ParseDateTime().Parse(parameters[4]),
                Format = parameters[5],
            };

            await _bookService.Update(toUpdate);
            Console.WriteLine("Success! Book updated");

            return true;
        }
    }
}

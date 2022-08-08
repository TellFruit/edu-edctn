namespace Portal.UI_Console.ConsoleCommands.Modify.Course.Remove
{
    internal class RemoveBookCommand : IConsoleCommand
    {
        private readonly CourseDTO _courseDTO;
        public RemoveBookCommand(CourseDTO course)
        {
            _courseDTO = course;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            Console.WriteLine("All included books: ");
            foreach (var material in _courseDTO.Materials)
            {
                var converted = material as BookDTO;

                if (converted.PageCount is not 0)
                {
                    Console.WriteLine(converted);
                }
            }

            ICollection<int> toRemove = new List<int>();
            int wantedId = 0;
            string input = "";
            do
            {
                Console.WriteLine("Write id of book to exclude or \'return\' to stop: ");

                input = Console.ReadLine();

                if (input.Equals("return"))
                {
                    break;
                }

                try { wantedId = int.Parse(input); }
                catch { if (!input.Equals("")) { input = ""; continue; } }

                if (toRemove.FirstOrDefault(x => x.Equals(wantedId)) is not 0)
                {
                    Console.WriteLine("Id already marked!");
                    continue;
                }

                toRemove.Add(wantedId);
            }
            while (true);

            var newMaterials = new List<MaterialDTO>();
            foreach (var material in _courseDTO.Materials)
            {
                var converted = material as BookDTO;

                if (converted.PageCount is not 0
                    && toRemove.Contains(converted.Id))
                {
                    continue;
                }

                newMaterials.Add(material);
            }

            _courseDTO.Materials = newMaterials;

            return true;
        }
    }
}

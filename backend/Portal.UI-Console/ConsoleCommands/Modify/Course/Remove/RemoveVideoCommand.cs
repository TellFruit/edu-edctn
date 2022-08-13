namespace Portal.UI_Console.ConsoleCommands.Modify.Course.Remove
{
    internal class RemoveVideoCommand : IConsoleCommand
    {
        private readonly CourseDTO _courseDTO;
        public RemoveVideoCommand(CourseDTO course)
        {
            _courseDTO = course;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            bool toContinue = false;
            Console.WriteLine("All included videos: ");
            foreach (var material in _courseDTO.Materials)
            {
                var converted = material as VideoDTO;

                if (converted is not null)
                {
                    toContinue = true;
                    Console.WriteLine(converted);
                }
            }

            ICollection<int> toRemove = new List<int>();
            int wantedId = 0;
            string input = string.Empty;
            do
            {
                Console.WriteLine("Write id of video to exclude or \'return\' to stop: ");

                input = Console.ReadLine();

                if (input.Equals("return"))
                {
                    break;
                }

                try
                {
                    wantedId = int.Parse(input);
                }
                catch
                {
                    if (!input.Equals(string.Empty))
                    {
                        input = string.Empty;
                        continue;
                    }
                }

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
                var converted = material as VideoDTO;

                if (converted is not null
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
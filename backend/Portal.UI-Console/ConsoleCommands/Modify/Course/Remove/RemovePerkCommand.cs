namespace Portal.UI_Console.ConsoleCommands.Modify.Course.Remove
{
    internal class RemovePerkCommand : IConsoleCommand
    {
        private readonly CourseDTO _courseDTO;
        public RemovePerkCommand(CourseDTO course)
        {
            _courseDTO = course;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            bool toContinue = false;
            Console.WriteLine("All included perks: ");
            foreach (var perk in _courseDTO.Perks)
            {
                if (perk is not null)
                {
                    toContinue = true;
                    Console.WriteLine(perk);
                }
            }

            if (!toContinue)
            {
                Console.WriteLine("No perks found! Returning...");
                return true;
            }

            ICollection<int> toRemove = new List<int>();
            int wantedId = 0;
            string input = string.Empty;
            do
            {
                Console.WriteLine("Write id of perk to exclude or \'return\' to stop: ");

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

            var newPerks = new List<PerkDTO>();
            foreach (var perk in _courseDTO.Perks)
            {
                if (perk is not null
                    && toRemove.Contains(perk.Id))
                {
                    continue;
                }

                newPerks.Add(perk);
            }

            _courseDTO.Perks = newPerks;

            return true;
        }
    }
}

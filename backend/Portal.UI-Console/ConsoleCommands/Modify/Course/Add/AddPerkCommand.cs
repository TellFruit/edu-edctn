namespace Portal.UI_Console.ConsoleCommands.Modify.Course.Add
{
    internal class AddPerkCommand : IConsoleCommand
    {
        private readonly IPerkService _perk;

        private readonly CourseDTO _courseDTO;

        public AddPerkCommand(IPerkService perkService, CourseDTO courseDTO)
        {
            _perk = perkService;
            _courseDTO = courseDTO;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            var configService = Program.Root.GetService<IConfigService>();

            var perks = await _perk.GetAll();

            var viewCommand = new PaginateCommand<PerkDTO>(configService, perks);

            Console.WriteLine("Take a look and write \'return\' to proceed and choose");
            await viewCommand.Run();

            int wantedId = 0;
            string input = string.Empty;
            do
            {
                ICollection<int> present = _courseDTO.Perks
                    .Select(x => x.Id).ToList();

                Console.WriteLine("Write id of wanted article or \'return\' to stop: ");

                input = Console.ReadLine();

                if (input.Equals("return"))
                {
                    return true;
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

                if (present.Contains(wantedId))
                {
                    Console.WriteLine("Already included!");
                    continue;
                }

                var wantedPerk = await _perk.GetById(wantedId);

                if (wantedPerk is null)
                {
                    Console.WriteLine("Not found");
                    continue;
                }

                _courseDTO.Perks.Add(wantedPerk);
            }
            while (true);
        }
    }
}

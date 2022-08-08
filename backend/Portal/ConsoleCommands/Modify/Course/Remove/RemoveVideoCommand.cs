using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("All included videos: ");
            foreach (var material in _courseDTO.Materials)
            {
                var converted = material as VideoDTO;

                if (converted.Quality is not 0)
                {
                    Console.WriteLine(converted);
                }
            }

            ICollection<int> toRemove = new List<int>();
            int wantedId = 0;
            string input = "";
            do
            {
                Console.WriteLine("Write id of video to exclude or \'return\' to stop: ");

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
                var converted = material as VideoDTO;

                if (converted.Quality is not 0
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
}

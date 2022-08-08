using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.UI_Console.ConsoleCommands.Modify.Course.Add
{
    internal class AddVideoCommand : IConsoleCommand
    {
        private readonly IVideoService _video;

        private readonly CourseDTO _courseDTO;

        public AddVideoCommand(IVideoService videoService, CourseDTO courseDTO)
        {
            _video = videoService;
            _courseDTO = courseDTO;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            var configService = Program.Root.GetService<IConfigService>();

            var videos = await _video.GetAll();

            var viewCommand = new PaginateCommand<VideoDTO>(configService, videos);

            Console.WriteLine("Take a look and write \'return\' to proceed and choose");
            await viewCommand.Run();

            ICollection<int> marked = new List<int>();
            int wantedId = 0;
            string input = "";
            do
            {
                Console.WriteLine("Write id of wanted video or \'return\' to stop: ");

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

                var wantedArticle = await _video.GetById(wantedId);

                _courseDTO.Materials.Add(wantedArticle);

                marked.Add(wantedId);
            }
            while (true);
        }
    }
}

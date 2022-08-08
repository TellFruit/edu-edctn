using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.UI_Console.ConsoleCommands.Modify.Materials.Video
{
    internal class CreateVideoCommand : IConsoleCommand
    {
        private readonly IVideoService _videoService;

        public CreateVideoCommand(IVideoService videoService)
        {
            _videoService = videoService;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            /* Examples of correct input:
             * Never Gonna Give You Up – 720, 00:04:12
             * Invaders Must die - 480, 00:05:32
             */

            var toCreate = new VideoDTO()
            {
                Title = parameters[0],
                Quality = int.Parse(parameters[1]),
                Duration = TimeSpan.Parse(parameters[2]),
            };

            await _videoService.Create(toCreate);
            Console.WriteLine("Success! Book created");

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.UI_Console.ConsoleCommands.Modify.Materials.Video
{
    internal class DeleteVideoCommand : IConsoleCommand
    {
        private readonly IVideoService _videoService;

        public DeleteVideoCommand(IVideoService videoService)
        {
            _videoService = videoService;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            await _videoService.Delete(int.Parse(parameters[0]));
            Console.WriteLine("Success! Video deleted");

            return true;
        }
    }
}

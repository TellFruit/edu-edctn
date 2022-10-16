namespace Portal.UI_Console.ConsoleCommands.Modify.Materials.Video
{
    internal class UpdateVideoCommand : IConsoleCommand
    {
        private readonly IVideoService _videoService;
        private readonly UserDTO _userDTO;

        public UpdateVideoCommand(IVideoService videoService, UserDTO userDTO)
        {
            _videoService = videoService;
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
             * 1 - Never Gonna Give You Up – 720p, 00:04:12
             * 2 - Invaders Must die - 480p, 00:05:32
             */

            var toUpdate = new VideoDTO()
            {
                Id = int.Parse(parameters[0]),
                Title = parameters[1],
                Quality = int.Parse(parameters[2]),
                Duration = TimeSpan.Parse(parameters[3]),
            };

            await _videoService.Update(toUpdate);
            Console.WriteLine("Success! Video updated");

            return true;
        }
    }
}

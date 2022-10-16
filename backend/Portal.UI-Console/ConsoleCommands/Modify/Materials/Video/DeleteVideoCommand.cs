namespace Portal.UI_Console.ConsoleCommands.Modify.Materials.Video
{
    internal class DeleteVideoCommand : IConsoleCommand
    {
        private readonly IVideoService _videoService;
        private readonly UserDTO _userDTO;

        public DeleteVideoCommand(IVideoService videoService, UserDTO userDTO)
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

            await _videoService.Delete(int.Parse(parameters[0]));
            Console.WriteLine("Success! Video deleted");

            return true;
        }
    }
}

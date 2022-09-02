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
            var userAuth = Program.Root.GetRequiredService<IUserAuth>();

            var auth = new AuthorizeCommand(userAuth);
            if (await auth.Run() is false)
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

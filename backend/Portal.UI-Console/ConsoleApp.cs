namespace Portal.UI_Console
{
    internal class ConsoleApp
    {
        private readonly ICommandManager _manager;

        public ConsoleApp(ICommandManager manager)
        {
            _manager = manager;
        }

        public async Task Start()
        {
            await _manager.InitCommandFlow();
        }
    }
}

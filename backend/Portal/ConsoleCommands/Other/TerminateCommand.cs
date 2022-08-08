namespace Portal.UI_Console.ConsoleCommands.Other
{
    internal class TerminateCommand : IConsoleCommand
    {
        public async Task<bool> Run(params string[] parameters)
        {
            Environment.Exit(0);

            return false;
        }
    }
}

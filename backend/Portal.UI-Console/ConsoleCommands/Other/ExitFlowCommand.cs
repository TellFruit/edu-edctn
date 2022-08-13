namespace Portal.UI_Console.ConsoleCommands.Other
{
    internal class ExitFlowCommand : IConsoleCommand
    {
        public async Task<bool> Run(params string[] parameters)
        {
            Console.WriteLine("Current flow is finished!");

            return false;
        }
    }
}

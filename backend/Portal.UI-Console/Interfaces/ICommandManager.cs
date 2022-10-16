namespace Portal.UI_Console.Interfaces
{
    internal interface ICommandManager
    {
        Task InitCommandFlow();

        IConsoleCommand GetCommand(string commandName);
    }
}

namespace Portal.UI_Console.Interfaces
{
    internal interface IConsoleCommand
    {
        Task<bool> Run(params string[] parameters);
    }
}

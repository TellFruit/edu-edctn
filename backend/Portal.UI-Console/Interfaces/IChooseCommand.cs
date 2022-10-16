namespace Portal.UI_Console.Interfaces
{
    internal interface IChooseCommand
    {
        IConsoleCommand Choose(out IParseInput? parser, string commandName);
    }
}

namespace Portal.UI_Console.Interfaces
{
    internal interface IParseValue<T> where T : struct
    {
        public T Parse(string input);

    }
}

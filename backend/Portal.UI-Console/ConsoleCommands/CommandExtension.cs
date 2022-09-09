namespace Portal.UI_Console.ConsoleCommands
{
    internal static class CommandExtension
    {
        public static ICollection<T> GetPaginatedPage<T>(this ICollection<T> collection, int page, int pageSize)
        {
            return collection.Skip((page - 1) * pageSize)
                                          .Take(pageSize)
                                          .ToList();
        }

        public static async Task<bool> CallAuthCommand(this UserDTO user)
        {
            var userAuth = Program.Root.GetRequiredService<IUserAuth>();

            var command = new AuthorizeCommand(userAuth, user);

            return await command.Run();
        }
    }
}

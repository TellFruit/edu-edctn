using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}

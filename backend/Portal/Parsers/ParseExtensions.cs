using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.UI_Console.Parsers
{
    internal static class ParseExtensions
    {
        public static int IndexOf<T>(this IEnumerable<T> source,
                            Func<T, bool> predicate)
        {
            int i = 0;

            foreach (T element in source)
            {
                if (predicate(element))
                    return i;

                i++;
            }

            return -1;
        }

        public static int IndexOf<T>(this IEnumerable<T> source, int startIndex,
                            Func<T, bool> predicate)
        {
            for (int i = 0; i < source.Count(); ++i)
            {
                if (i < startIndex)
                    continue;

                if (predicate(source.ElementAt(i)))
                    return i;
            }

            return -1;
        }
    }
}

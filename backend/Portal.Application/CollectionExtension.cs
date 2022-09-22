namespace Portal.Application
{
    public static class CollectionExtension
    {
        public static IEnumerable<T> AddRange<T>(this IEnumerable<T> list, IEnumerable<T> values)
        {
            foreach (var item in values)
            {
                list.Append(item);
            }

            return list;
        }
    }
}

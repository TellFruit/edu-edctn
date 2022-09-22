namespace Portal.UI_MVC_Web.Services
{
    public static class CollectionExtension
    {
        public static ICollection<T> AddRange<T>(this ICollection<T> list, ICollection<T> values)
        {
            foreach (var item in values)
            {
                list.Add(item);
            }

            return list;
        }
    }
}

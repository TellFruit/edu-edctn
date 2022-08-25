namespace Portal.Persistence_EF_Core.Repositories.Generic
{
    internal static class GenericRepository
    {
        public static IQueryable<T> IncludeSeveral<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes)
            where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return query;
        }
    }
}

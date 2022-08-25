namespace Portal.Persistence_EF_Core.Interfaces
{
    internal interface IEntityRepository<TEntity> where TEntity : FrameworkEntity
    {
        Task Create(TEntity item);

        Task<IEnumerable<TEntity>> Read(params Expression<Func<TEntity, object>>[] includeProperties);

        Task<IEnumerable<TEntity>> Read(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties);

        Task Update(TEntity item);

        Task Remove(TEntity item);
    }
}

namespace Portal.Persistence_EF_Core.Interfaces
{
    internal interface IEntityRepository<TEntity> where TEntity : FrameworkEntity
    {
        void Create(TEntity item);

        IEnumerable<TEntity> Read(params Expression<Func<TEntity, object>>[] includeProperties);

        IEnumerable<TEntity> Read(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties);

        void Update(TEntity item);

        void Remove(TEntity item);
    }
}

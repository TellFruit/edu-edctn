namespace Portal.Persistence_EF_Core.Interfaces
{
    internal interface IEntityRepository<TEntity> where TEntity : FrameworkEntity
    {
        Task Create(TEntity item);

        Task<ICollection<TEntity>> Read(params Expression<Func<TEntity, object>>[] includeProperties);

        Task<ICollection<TEntity>> Read(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] toInclude);

        Task Update(TEntity item);

        Task Remove(TEntity item);

        void Save();
    }
}

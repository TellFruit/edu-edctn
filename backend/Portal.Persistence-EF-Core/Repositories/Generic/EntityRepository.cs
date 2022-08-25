namespace Portal.Persistence_EF_Core.Repositories.Generic
{
    internal class EntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : FrameworkEntity
    {
        private readonly PortalContext _context;
        private DbSet<TEntity> _dbSet;

        public EntityRepository(PortalContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public Task Create(TEntity item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> Read(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> Read(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task Remove(TEntity item)
        {
            throw new NotImplementedException();
        }

        public Task Update(TEntity item)
        {
            throw new NotImplementedException();
        }
    }
}

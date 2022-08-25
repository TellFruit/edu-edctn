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

        public async Task Create(TEntity item)
        {
            _dbSet.Add(item);
        }

        public async Task<ICollection<TEntity>> Read(params Expression<Func<TEntity, object>>[] toInclude)
        {
            return _dbSet
                .IncludeSeveral(toInclude)
                .ToList();
        }

        public async Task<ICollection<TEntity>> Read(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] toInclude)
        {
            return _dbSet
                .IncludeSeveral(toInclude)
                .Where(predicate)
                .ToList();
        }

        public Task Remove(TEntity item)
        {
            throw new NotImplementedException();
        }

        public Task Update(TEntity item)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

namespace Portal.Application.Interfaces.OuterImpl
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> Create(TEntity entity);
        Task<ICollection<TEntity>> Read();
        Task<ICollection<TEntity>> Read(Func<TEntity, bool> predicate);
        Task<TEntity> Update(TEntity entity);
        Task<int> Delete(TEntity entity);
        void SaveChanges();
    }
}

namespace Portal.Application.Interfaces.OuterImpl
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> Create(TEntity entity);
        Task<ICollection<TEntity>> Read();
        Task<TEntity> Update(TEntity entity);
        Task<int> Delete(TEntity entity);
        Task SaveChanges();
    }
}

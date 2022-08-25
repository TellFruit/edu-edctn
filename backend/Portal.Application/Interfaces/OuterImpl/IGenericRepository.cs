namespace Portal.Application.Interfaces.OuterImpl
{
    public interface IGenericRepository<TDomain> where TDomain : BaseDomain
    {
        Task<TDomain> Create(TDomain entity);
        Task<ICollection<TDomain>> Read();
        Task<TDomain> Update(TDomain entity);
        Task<int> Delete(TDomain entity);
        void SaveChanges();
    }
}

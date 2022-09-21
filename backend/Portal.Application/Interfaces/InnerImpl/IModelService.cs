namespace Portal.Application.Interfaces.InnerImpl
{
    public interface IModelService<TDto, TDomain> where TDto : class
                                                  where TDomain : BaseEntity
    {
        Task<TDto> Create(TDto entity);
        Task<ICollection<TDto>> GetAll();
        Task<TDto> GetById(int id);
        Task<ICollection<TDto>> GetBySpec(ISpecification<TDomain> specification);
        Task<TDto> Update(TDto entity);
        Task<int> Delete(int id);
    }
}

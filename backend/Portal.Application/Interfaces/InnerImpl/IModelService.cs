namespace Portal.Application.Interfaces.InnerImpl
{
    public interface IModelService<TEntityDTO> where TEntityDTO : class
    {
        Task<TEntityDTO> Create(TEntityDTO entity);
        Task<ICollection<TEntityDTO>> GetAll();
        Task<TEntityDTO> GetById(int id);
        Task<TEntityDTO> Update(TEntityDTO entity);
        Task<int> Delete(int id);
    }
}

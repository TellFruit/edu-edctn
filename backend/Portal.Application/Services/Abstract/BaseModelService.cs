namespace Portal.Application.Services.Abstract
{
    internal abstract class BaseModelService<TEntity> where TEntity : BaseEntity
    {
        protected readonly IMapper _mapper;
        protected readonly IGenericRepository<TEntity> _repository;

        public BaseModelService(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}

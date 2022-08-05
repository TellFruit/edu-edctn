using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

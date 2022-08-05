using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Interfaces.Inner
{
    internal interface IModelService<TEntity, TEntityDTO> where TEntity : BaseEntity 
                                                            where TEntityDTO : class
    {
        Task<TEntity> Create(TEntityDTO entity);
        Task<ICollection<TEntity>> GetAll();
        Task<TEntity> Update(TEntityDTO entity);
        Task<int> Delete(TEntityDTO entity);
    }
}

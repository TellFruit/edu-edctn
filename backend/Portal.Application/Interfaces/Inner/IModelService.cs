using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Interfaces.Inner
{
    internal interface IModelService<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> Create(TEntity entity);
        Task<ICollection<TEntity>> GetAll();
        Task<TEntity> Update(TEntity entity);
        Task<int> Delete(TEntity entity);
    }
}

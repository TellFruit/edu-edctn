using Portal.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Interfaces.Outer
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

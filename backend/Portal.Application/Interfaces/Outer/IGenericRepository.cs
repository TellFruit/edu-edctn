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
        void Create(TEntity entity);
        ICollection<TEntity> Read();
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void SaveChanges();
    }
}

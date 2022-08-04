using Portal.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Interfaces.Outer
{
    // Base interface for further inheritence if needed.
    // In theory it can be universal for both async and sync implementations.
    public interface IBaseUnitOfWork
    {
        // Method to get repository of any type. Details are up to the client
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;

        // Method to save info from all the repositories to the source
        void SaveAllChanges();
    }
}

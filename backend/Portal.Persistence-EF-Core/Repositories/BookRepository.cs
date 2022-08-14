using AutoMapper;
using Portal.Application.Interfaces.OuterImpl;
using Portal.Domain.Entities;
using Portal.Persistence_EF_Core.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Persistence_EF_Core.Repositories
{
    internal class BookRepository : BaseRepository, IGenericRepository<BookDomain>
    {
        public BookRepository(IMapper mapper, PortalContext context)
            : base(mapper, context) {}

        public Task<BookDomain> Create(BookDomain entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(BookDomain entity)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<BookDomain>> Read()
        {
            throw new NotImplementedException();
        }

        public Task SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<BookDomain> Update(BookDomain entity)
        {
            throw new NotImplementedException();
        }
    }
}

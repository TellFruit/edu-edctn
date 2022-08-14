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
    internal class VideoRepository : BaseRepository, IGenericRepository<VideoDomain>
    {
        public VideoRepository(IMapper mapper, PortalContext context) 
            : base(mapper, context) {}

        public Task<VideoDomain> Create(VideoDomain entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(VideoDomain entity)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<VideoDomain>> Read()
        {
            throw new NotImplementedException();
        }

        public Task SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<VideoDomain> Update(VideoDomain entity)
        {
            throw new NotImplementedException();
        }
    }
}

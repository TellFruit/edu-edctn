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
    internal class CourseRepository : BaseRepository, IGenericRepository<CourseDomain>
    {
        public CourseRepository(IMapper mapper, PortalContext context)
            : base(mapper, context) {}

        public Task<CourseDomain> Create(CourseDomain entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(CourseDomain entity)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<CourseDomain>> Read()
        {
            throw new NotImplementedException();
        }

        public Task SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<CourseDomain> Update(CourseDomain entity)
        {
            throw new NotImplementedException();
        }
    }
}

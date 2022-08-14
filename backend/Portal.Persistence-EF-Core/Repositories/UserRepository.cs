using AutoMapper;
using Portal.Application.Interfaces.OuterImpl;
using Portal.Domain.Entities;
using Portal.Persitence_EF_Core.FrameworkEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Persistence_EF_Core.Repositories
{
    internal class UserRepository : IGenericRepository<UserDomain>
    {
        private readonly IMapper _mapper;
        private readonly PortalContext _context;

        public UserRepository(IMapper mapper, PortalContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<UserDomain> Create(UserDomain entity)
        {
            var userEntity = _mapper.Map<User>(entity);

            await _context.AddAsync(userEntity);

            return entity;
        }

        public Task<int> Delete(UserDomain entity)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<UserDomain>> Read()
        {
            throw new NotImplementedException();
        }

        public Task SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<UserDomain> Update(UserDomain entity)
        {
            throw new NotImplementedException();
        }
    }
}

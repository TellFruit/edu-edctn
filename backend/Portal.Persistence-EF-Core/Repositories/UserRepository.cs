using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

            _context.Add(userEntity);

            return entity;
        }

        public async Task<int> Delete(UserDomain entity)
        {
            var userEntity = await _context.Users.FirstOrDefaultAsync(u => u.Id == entity.Id);

            //if (userEntity == null)
            //{
            //    throw new NotFoundException(nameof(User), userId);
            //}

            _context.Users.Remove(userEntity);
            return userEntity.Id;
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

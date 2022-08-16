using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Portal.Application.Interfaces.OuterImpl;
using Portal.Domain.Entities;
using Portal.Persistence_EF_Core.Repositories.Abstract;
using Portal.Persitence_EF_Core.FrameworkEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Persistence_EF_Core.Repositories
{
    internal class UserRepository : BaseRepository, IGenericRepository<UserDomain>
    {
        public UserRepository(IMapper mapper, PortalContext context)
            : base(mapper, context) {}

        public async Task<UserDomain> Create(UserDomain entity)
        {
            var userEntity = _mapper.Map<User>(entity);

            _context.Users.Add(userEntity);

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

        public async Task<ICollection<UserDomain>> Read()
        {
            var users = _context.Users.ToList();

            return users.Select(x => _mapper.Map<UserDomain>(x)).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task<UserDomain> Update(UserDomain entity)
        {
            var userEntity = await _context.Users.FirstOrDefaultAsync(u => u.Id == entity.Id);

            var data = _mapper.Map<User>(entity);

            userEntity.FirstName = data.FirstName;
            userEntity.LastName = data.LastName;
            userEntity.Email = data.Email;
            userEntity.Password = data.Password;
            userEntity.Roles = data.Roles;
            userEntity.UpdatedAt = data.UpdatedAt;

            _context.Update(userEntity);

            return entity;
        }
    }
}

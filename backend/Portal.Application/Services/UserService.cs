using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Services
{
    internal class UserService : BaseModelService<User>, IModelService<UserDTO>
    {
        public UserService(IGenericRepository<User> repository, IMapper mapper)
            : base(repository, mapper) {}

        public async Task<UserDTO> Create(UserDTO entity)
        {
            var user = _mapper.Map<User>(entity);

            user.CreatedAt = DateTime.Now;

            await _repository.Create(user);
            await _repository.SaveChanges();

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<int> Delete(int id)
        {
            var users = await _repository.Read();
            var toDelete = users.FirstOrDefault(a => a.Id.Equals(id));

            if (toDelete is null)
            {
                throw new EntityNotFoundException(nameof(Perk));
            }

            return await _repository.Delete(toDelete);
        }

        public Task<ICollection<UserDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> Update(UserDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}

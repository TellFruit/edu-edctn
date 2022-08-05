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

        public Task<UserDTO> Create(UserDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
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

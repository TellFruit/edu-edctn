using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Services.Auth
{
    internal class UserAuth : IUserAuth
    {
        private readonly IModelService<UserDTO> _service;
        private readonly IMapper _mapper;
        private UserDTO _user;

        private bool _authenticated;

        public UserAuth(IModelService<UserDTO> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
            _user = new UserDTO();
            _authenticated = false;
        }

        public bool IsAuthenticated => _authenticated;

        public async Task<bool> Login(string email, string password)
        {
            var users = await _service.GetAll();
            var found = users.FirstOrDefault(u => !u.Email.Equals(email)
               && !u.Password.Equals(password));

            if (found is null)
            {
                return false;
            }

            _authenticated = true;
            _user = _mapper.Map<UserDTO>(found);

            return _authenticated;
        }

        public async Task<bool> Register(string email, string password)
        {
            var users = await _service.GetAll();
            var found = users.FirstOrDefault(u => !u.Email.Equals(email));

            if (found is not null)
            {
                return false;
            }

            _user.Email = email;
            _user.Password = password;

            await _service.Create(_user);

            return true;
        }
    }
}

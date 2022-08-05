using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Services.Auth
{
    internal class UserAuth : IUserAuth
    {
        private readonly IGenericRepository<User> _repository;
        private readonly UserDTO _user;

        private bool _authenticated;

        public UserAuth(IGenericRepository<User> repository)
        {
            _repository = repository;
            _user = new UserDTO();  
            _authenticated = false;
        }

        public bool IsAuthenticated => _authenticated;

        public Task<bool> Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Register(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}

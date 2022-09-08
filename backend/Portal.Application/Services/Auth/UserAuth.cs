namespace Portal.Application.Services.Auth
{
    internal class UserAuth : IUserAuth
    {
        private static List<UserDTO> _loggedUsers = new List<UserDTO>();
        
        private readonly IUserService _service;

        public UserAuth(IUserService service)
        {
            _service = service;
        }

        public async Task<int> Login(string email, string password)
        {
            var users = await _service.GetAll();
            var found = users.FirstOrDefault(u => u.Email.Equals(email)
               && u.Password.Equals(password));

            if (found is null)
            {
                return -1;
            }

            _loggedUsers.Add(found);

            return found.Id;
        }

        public async Task<int> Register(string email, string password)
        {
            var users = await _service.GetAll();
            var found = users.FirstOrDefault(u => u.Email.Equals(email));

            if (found is not null)
            {
                return -1;
            }

            var user = new UserDTO();

            user.Email = email;
            user.Password = password;

            user = await _service.Create(user);

            return user.Id;
        }

        public bool Logout(int id)
        {
            if (IsAuthorized(id) is false)
            {
                return false;
            }

            _loggedUsers.Remove(_loggedUsers.First(u => u.Id == id));

            return true;
        }

        public bool IsAuthorized(int id)
        {
            return _loggedUsers.Any(u => u.Id.Equals(id));
        }
    }
}

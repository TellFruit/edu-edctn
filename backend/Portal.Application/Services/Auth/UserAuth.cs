namespace Portal.Application.Services.Auth
{
    internal class UserAuth : IUserAuth
    {
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
                return default;
            }

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
            user.Role = Roles.Learner;

            user = await _service.Create(user);

            return user.Id;
        }

        public async Task<bool> IsAuthorized(int id)
        {
            var users = await _service.GetAll();

            return users.Any(u => u.Id.Equals(id));
        }
    }
}

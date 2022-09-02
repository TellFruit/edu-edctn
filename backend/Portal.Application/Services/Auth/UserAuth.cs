namespace Portal.Application.Services.Auth
{
    internal class UserAuth : IUserAuth
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;
        private UserDTO _user;

        private bool _authenticated;

        public UserAuth(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
            _user = new UserDTO();
            _authenticated = false;
        }

        public bool IsAuthenticated => _authenticated;

        public int LoggedId => _user.Id is 0 ? -1 : _user.Id;

        public async Task<bool> Login(string email, string password)
        {
            var users = await _service.GetAll();
            var found = users.FirstOrDefault(u => u.Email.Equals(email)
               && u.Password.Equals(password));

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
            var found = users.FirstOrDefault(u => u.Email.Equals(email));

            if (found is not null)
            {
                return false;
            }

            _user = await _service.Create(_user);

            _authenticated = true;

            return true;
        }

        public async Task<bool> Logout()
        {
            if (!IsAuthenticated)
            {
                return false;
            }

            _user = new UserDTO();
            _authenticated = false;

            return true;
        }
    }
}

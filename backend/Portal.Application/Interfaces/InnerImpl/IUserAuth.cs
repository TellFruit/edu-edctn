namespace Portal.Application.Interfaces.InnerImpl
{
    public interface IUserAuth
    {
        public Task<bool> Login(string email, string password);

        public Task<bool> Register(string email, string password);

        public bool Logout(int id);

        public bool IsAuthorized(int id);
    }
}

namespace Portal.Application.Interfaces.InnerImpl
{
    public interface IUserAuth
    {
        public Task<int> Login(string email, string password);

        public Task<int> Register(string email, string password);

        public bool Logout(int id);

        public bool IsAuthorized(int id);
    }
}

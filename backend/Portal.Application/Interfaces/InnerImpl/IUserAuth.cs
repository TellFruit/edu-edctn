namespace Portal.Application.Interfaces.InnerImpl
{
    public interface IUserAuth
    {
        public Task<int> Login(string email, string password);

        public Task<int> Register(string email, string password);

        public Task<bool> IsAuthorized(int id);
    }
}

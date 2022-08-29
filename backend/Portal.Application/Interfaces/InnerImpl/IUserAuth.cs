namespace Portal.Application.Interfaces.InnerImpl
{
    public interface IUserAuth
    {
        public bool IsAuthenticated { get; }
        public int LoggedId { get; }
        Task<bool> Login(string email, string password);
        Task<bool> Register(string email, string password);
        Task<bool> Logout();
    }
}

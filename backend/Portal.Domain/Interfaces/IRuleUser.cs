namespace Portal.Domain.Interfaces
{
    public interface IRuleUser
    {
        Task<bool> Enroll(int userId, int courseId);
        Task<bool> Unroll(int userId, int courseId);
    }
}

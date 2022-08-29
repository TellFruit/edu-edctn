namespace Portal.Domain.Interfaces
{
    public interface IRuleUser
    {
        Task<bool> Enroll(int userId, int courseId);
        Task<bool> Unenroll(int userId, int courseId);
    }
}

namespace Portal.Domain.Interfaces
{
    public interface IRuleUser
    {
        Task<bool> Enroll(int userId, int courseId);
        Task<bool> Unenroll(int userId, int courseId);
        Task<bool> MarkLearned(int userId, int materialId);
        Task<bool> UnmarkLearned(int userId, int materialId);
    }
}

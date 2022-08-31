namespace Portal.Application.Interfaces.InnerImpl
{
    public interface IRuleUser
    {
        Task<UserDTO> Enroll(int userId, int courseId);
        Task<UserDTO> Unenroll(int userId, int courseId);
        Task<UserDTO> MarkLearned(int userId, int materialId);
        Task<UserDTO> UnmarkLearned(int userId, int materialId);
    }
}

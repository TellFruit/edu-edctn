namespace Portal.Domain.Interfaces
{
    public interface IRuleUser
    {
        Task<bool> Enroll(int courseId);
        Task<bool> Unroll(int courseId);
    }
}

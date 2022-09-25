namespace Portal.UI_MVC_Web.Interfaces
{
    public interface IAttendViewModelService
    {
        IAttendViewModelService SetUser(UserDTO user);

        Task<CourseIndexModel> GetAttendedCourses();

        Task<AttendViewModel> GetAttendModelById(int courseId);
    }
}

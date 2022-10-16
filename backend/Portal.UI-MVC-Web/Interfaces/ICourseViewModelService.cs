namespace Portal.UI_MVC_Web.Interfaces
{
    public interface ICourseViewModelService
    {
        CourseViewModel ToCourseViewModel(CourseDTO courseDTO);

        Task<CourseViewModel> ToCourseViewModelWithUnmarked(CourseDTO courseDTO);

        Task<CourseViewModel> ToCourseViewModelById(int courseId);

        Task<CourseViewModel> ToCourseViewModelByIdWithUnmarked(int courseId);

        CourseDTO ToCourseDto(CourseViewModel courseViewModel);

        Task<CourseIndexModel> GetCourseIndexModel();

        Task CallCreateCourse(CourseViewModel courseViewModel);

        Task CallUpdateCourse(CourseViewModel courseViewModel);

        Task CallDeleteCourse(int id);
    }
}
namespace Portal.UI_MVC_Web.Interfaces
{
    internal interface ICourseViewModelService
    {
        public CourseViewModel ToCourseViewModel(CourseDTO courseDTO);

        public Task<CourseViewModel> ToCourseViewModelWithUnmarked(CourseDTO courseDTO);

        public Task<CourseViewModel> ToCourseViewModelById(int courseId);

        public Task<CourseViewModel> ToCourseViewModelByIdWithUnmarked(int courseId);

        public CourseDTO ToCourseDto(CourseViewModel courseViewModel);

        public Task<CourseIndexModel> GetCourseIndexModel();

        public Task CallCreateCourse(CourseViewModel courseViewModel);

        public Task CallUpdateCourse(CourseViewModel courseViewModel);
    }
}
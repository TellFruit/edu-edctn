namespace Portal.UI_MVC_Web.Interfaces
{
    internal interface ICourseViewModelService
    {
        public Task<CourseViewModel> ToCourseViewModel(CourseDTO courseDTO);

        public Task<CourseDTO> ToCourseDto(CourseViewModel courseViewModel);

        public Task CallCreateCourse(CourseViewModel courseViewModel);

        public Task CallUpdateCourse(CourseViewModel courseViewModel);
    }
}
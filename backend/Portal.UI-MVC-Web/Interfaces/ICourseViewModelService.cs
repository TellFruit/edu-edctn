﻿namespace Portal.UI_MVC_Web.Interfaces
{
    internal interface ICourseViewModelService
    {
        public Task<CourseViewModel> ToCourseViewModel(CourseDTO courseDTO);

        public Task<CourseViewModel> ToCourseViewModelById(int courseId);

        public CourseDTO ToCourseDto(CourseViewModel courseViewModel);


        public Task CallCreateCourse(CourseViewModel courseViewModel);

        public Task CallUpdateCourse(CourseViewModel courseViewModel);
    }
}
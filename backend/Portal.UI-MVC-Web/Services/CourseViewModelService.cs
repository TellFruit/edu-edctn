namespace Portal.UI_MVC_Web.Services
{
    internal class CourseViewModelService : ICourseViewModelService
    {
        private readonly ICourseService _courseService;
        private readonly IArticleService _articleService;
        private readonly IVideoService _videoService;
        private readonly IBookService _bookService;


        public CourseViewModelService(ICourseService courseService, IArticleService articleService, IVideoService videoService, IBookService bookService)
        {
            _courseService = courseService;
            _articleService = articleService;
            _videoService = videoService;
            _bookService = bookService;
        }

        public async Task CallCreateCourse(CourseViewModel courseViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task CallUpdateCourse(CourseViewModel courseViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task<CourseDTO> ToCourseDto(CourseViewModel courseViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task<CourseViewModel> ToCourseViewModel(CourseDTO courseDTO)
        {
            throw new NotImplementedException();
        }
    }
}

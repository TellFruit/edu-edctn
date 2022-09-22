namespace Portal.UI_MVC_Web.Services
{
    internal class CourseViewModelService : ICourseViewModelService
    {
        private readonly ICourseService _courseService;
        private readonly IArticleService _articleService;
        private readonly IVideoService _videoService;
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public CourseViewModelService(ICourseService courseService, IArticleService articleService, IVideoService videoService, IBookService bookService, IMapper mapper)
        {
            _courseService = courseService;
            _articleService = articleService;
            _videoService = videoService;
            _bookService = bookService;
            _mapper = mapper;
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
            var courseViewModel = _mapper.Map<CourseViewModel>(courseDTO);

            var spec = new ArticleNotIncludedSpec(courseViewModel.Articles.Select(a => a.Id));
            var unmarkedArticles = await _articleService.GetBySpec(spec);
            var castedArticles = _mapper.Map<ICollection<CourseArticleModel>>(unmarkedArticles);

            courseViewModel.Articles.Add(castedArticles.First());
        }

        public async Task<CourseViewModel> ToCourseViewModelById(int courseId)
        {
            var course = await _courseService.GetById(courseId);

            return await ToCourseViewModel(course);
        }
    }
}

namespace Portal.UI_MVC_Web.Services
{
    internal class CourseViewModelService : ICourseViewModelService
    {
        private readonly ICourseService _courseService;
        private readonly IArticleService _articleService;
        private readonly IVideoService _videoService;
        private readonly IBookService _bookService;
        private readonly IPerkService _perkService;
        private readonly IMapper _mapper;

        public CourseViewModelService(ICourseService courseService, IArticleService articleService, IVideoService videoService, IBookService bookService, IMapper mapper, IPerkService perkService)
        {
            _courseService = courseService;
            _articleService = articleService;
            _videoService = videoService;
            _bookService = bookService;
            _perkService = perkService;
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

            courseViewModel.Articles.AddRange(await GetArticlesNotIncluded(courseViewModel));

            courseViewModel.Books.AddRange(await GetBooksNotIncluded(courseViewModel));

            courseViewModel.Videos.AddRange(await GetVideoNotIncluded(courseViewModel));

            return courseViewModel;
        }

        public async Task<CourseViewModel> ToCourseViewModelById(int courseId)
        {
            var course = await _courseService.GetById(courseId);

            return await ToCourseViewModel(course);
        }

        private async Task<ICollection<CourseArticleModel>> GetArticlesNotIncluded(CourseViewModel courseViewModel)
        {
            var spec = new ArticleNotIncludedSpec(courseViewModel.Articles.Select(a => a.Id));
            var unmarkedArticles = await _articleService.GetBySpec(spec);
            var castedArticles = _mapper.Map<ICollection<CourseArticleModel>>(unmarkedArticles);

            return castedArticles;
        }

        private async Task<ICollection<CourseBookModel>> GetBooksNotIncluded(CourseViewModel courseVideoModel)
        {
            var spec = new BookNotIncludedSpec(courseVideoModel.Books.Select(a => a.Id));
            var unmarkedBooks = await _bookService.GetBySpec(spec);
            var castedBooks = _mapper.Map<ICollection<CourseBookModel>>(unmarkedBooks);

            return castedBooks;
        }

        private async Task<ICollection<CourseVideoModel>> GetVideoNotIncluded(CourseViewModel courseVideoModel)
        {
            var spec = new VideoNotIncludedSpec(courseVideoModel.Videos.Select(a => a.Id));
            var unmarkedVideos = await _videoService.GetBySpec(spec);
            var castedVideos = _mapper.Map<ICollection<CourseVideoModel>>(unmarkedVideos);

            return castedVideos;
        }
    }
}

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
            var courseDTO = ToCourseDto(courseViewModel);

            await _courseService.Create(courseDTO);
        }

        public async Task CallUpdateCourse(CourseViewModel courseViewModel)
        {
            var courseDTO = ToCourseDto(courseViewModel);

            await _courseService.Update(courseDTO);
        }

        public CourseDTO ToCourseDto(CourseViewModel courseViewModel)
        {
            var courseDTO = _mapper.Map<CourseDTO>(courseViewModel);

            var selectedArticles = courseViewModel.Articles.Where(x => x.IsSelected);
            var castedArticles = _mapper.Map<ICollection<MaterialDTO>>(selectedArticles);
            courseDTO.Materials.AddRange(castedArticles);

            var selectedVideos = courseViewModel.Videos.Where(x => x.IsSelected);
            var castedVideos = _mapper.Map<ICollection<MaterialDTO>>(selectedVideos);
            courseDTO.Materials.AddRange(castedVideos);

            var selectedBooks = courseViewModel.Books.Where(x => x.IsSelected);
            var castedBooks = _mapper.Map<ICollection<MaterialDTO>>(selectedBooks);
            courseDTO.Materials.AddRange(castedBooks);

            var selectedPerks = courseViewModel.Perks.Where(x => x.IsSelected);
            var castedPerks = _mapper.Map<ICollection<PerkDTO>>(selectedPerks);
            courseDTO.Perks = castedPerks;

            return courseDTO;
        }

        public CourseViewModel ToCourseViewModel(CourseDTO courseDTO)
        {
            var courseViewModel = _mapper.Map<CourseViewModel>(courseDTO);

            return courseViewModel;
        }
        public async Task<CourseViewModel> ToCourseViewModelWithUnmarked(CourseDTO courseDTO)
        {
            var courseViewModel = ToCourseViewModel(courseDTO);

            courseViewModel.Articles.AddRange(await GetArticlesNotIncluded(courseViewModel));

            courseViewModel.Books.AddRange(await GetBooksNotIncluded(courseViewModel));

            courseViewModel.Videos.AddRange(await GetVideosNotIncluded(courseViewModel));

            courseViewModel.Perks.AddRange(await GetPerksNotIncluded(courseViewModel));

            return courseViewModel;
        }

        public async Task<CourseViewModel> ToCourseViewModelById(int courseId)
        {
            var course = await _courseService.GetById(courseId);

            return ToCourseViewModel(course);
        }

        public async Task<CourseViewModel> ToCourseViewModelByIdWithUnmarked(int courseId)
        {
            var course = await _courseService.GetById(courseId);

            return await ToCourseViewModelWithUnmarked(course);
        }

        public async Task<CourseIndexModel> GetCourseIndexModel()
        {
            var course = await _courseService.GetAll();

            return new CourseIndexModel(course);
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

        private async Task<ICollection<CourseVideoModel>> GetVideosNotIncluded(CourseViewModel courseVideoModel)
        {
            var spec = new VideoNotIncludedSpec(courseVideoModel.Videos.Select(a => a.Id));
            var unmarkedVideos = await _videoService.GetBySpec(spec);
            var castedVideos = _mapper.Map<ICollection<CourseVideoModel>>(unmarkedVideos);

            return castedVideos;
        }

        private async Task<ICollection<CoursePerkModel>> GetPerksNotIncluded(CourseViewModel courseVideoModel)
        {
            var spec = new PerkNotIncludedSpec(courseVideoModel.Perks.Select(a => a.Id));
            var unmarkedPerks = await _perkService.GetBySpec(spec);
            var castedPerks = _mapper.Map<ICollection<CoursePerkModel>>(unmarkedPerks);

            return castedPerks;
        }
    }
}
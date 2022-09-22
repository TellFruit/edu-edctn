namespace Portal.UI_MVC_Web.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;

        public CourseController(ICourseService courseService, IArticleService articleService, IMapper mapper)
        {
            _courseService = courseService;
            _articleService = articleService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await GetCourseIndexModel());
        }

        public async Task<IActionResult> AddOrEdit(int? id)
        {
            CourseDTO course;

            if (id == null)
            {
                course = new CourseDTO();
            }
            else
            {
                course = await _courseService.GetById(id.Value);
            }

            var courseViewModel = _mapper.Map<CourseViewModel>(course);

            var spec = new ArticleNotIncludedSpec(courseViewModel.Articles.Select(a => a.Id));
            var unmarkedArticles = await _articleService.GetBySpec(spec);
            var castedArticles = _mapper.Map<ICollection<CourseArticleModel>>(unmarkedArticles);

            courseViewModel.Articles.Add(castedArticles.First());

            return View(courseViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrEdit(CourseViewModel courseViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(courseViewModel);
            }

            if (courseViewModel.Id.Equals(default))
            {
                var courseDTO = _mapper.Map<CourseDTO>(courseViewModel);
                var selectedArticles = courseViewModel.Articles.Where(a => a.IsSelected).ToList();
                var articleDTOs = _mapper.Map<ICollection<ArticleDTO>>(selectedArticles);

                courseDTO.Materials.Add(articleDTOs.First());

                await _courseService.Create(courseDTO);
            }
            else
            {
                //await _bookService.Update(book);
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<CourseIndexModel> GetCourseIndexModel()
        {
            var course = await _courseService.GetAll();

            return new CourseIndexModel(course);
        }
    }
}

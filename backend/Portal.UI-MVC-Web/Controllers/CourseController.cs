using Portal.Domain.Entities.Material.Specification;

namespace Portal.UI_MVC_Web.Controllers
{
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

        public IActionResult Index()
        {
            return View();
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

            courseViewModel.Articles.Union(unmarkedArticles);

            return View(course);
        }
    }
}

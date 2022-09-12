namespace Portal.UI_MVC_Web.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<IActionResult> Index()
        {
            var articles = await _articleService.GetAll();

            var model = new ArticleIndexModel(articles);

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Url,Published")] ArticleDTO article)
        {
            await _articleService.Create(article);

            return RedirectToAction(nameof(Index));
        }
    }
}

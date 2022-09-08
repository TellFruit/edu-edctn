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
    }
}

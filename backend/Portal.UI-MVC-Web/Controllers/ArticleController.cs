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

        public async Task<IActionResult> AddOrEdit(int? id)
        {
            ArticleDTO article;

            if(id == null)
            {
                article = new ArticleDTO();
            }
            else
            {
                article = await _articleService.GetById(id.Value);
            }

            return View(article);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(ArticleDTO article)
        {
            if (!ModelState.IsValid)
            {
                return View(article);
            }

            if (article.Id.Equals(default))
            {
                await _articleService.Create(article);
            }
            else
            {
                await _articleService.Update(article);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

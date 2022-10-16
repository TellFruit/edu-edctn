namespace Portal.UI_MVC_Web.Controllers
{
    [Authorize]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await GetArticleIndexModel());
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

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _articleService.Delete(id);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return PartialView("_ArticlePartial", await GetArticleIndexModel());
        }

        private async Task<ArticleIndexModel> GetArticleIndexModel()
        {
            var articles = await _articleService.GetAll();

            return new ArticleIndexModel(articles);
        }
    }
}

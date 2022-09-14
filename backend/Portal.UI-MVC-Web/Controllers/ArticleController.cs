﻿namespace Portal.UI_MVC_Web.Controllers
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
            return View(await GetArticleIndexMode());
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

            return PartialView("_ArticlePartial", await GetArticleIndexMode());
        }

        private async Task<ArticleIndexModel> GetArticleIndexMode()
        {
            var articles = await _articleService.GetAll();

            return new ArticleIndexModel(articles);
        }
    }
}

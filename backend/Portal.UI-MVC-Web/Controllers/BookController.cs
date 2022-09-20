namespace Portal.UI_MVC_Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await GetArticleIndexModel());
        }

        public async Task<IActionResult> AddOrEdit(int? id)
        {
            BookDTO book;

            if (id == null)
            {
                book = new BookDTO();
            }
            else
            {
                book = await _bookService.GetById(id.Value);
            }

            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(BookDTO book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }

            if (book.Id.Equals(default))
            {
                await _bookService.Create(book);
            }
            else
            {
                await _bookService.Update(book);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _bookService.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return PartialView("_ArticlePartial", await GetArticleIndexModel());
        }

        private async Task<BookIndexModel> GetArticleIndexModel()
        {
            var articles = await _bookService.GetAll();

            return new BookIndexModel(articles);
        }
    }
}

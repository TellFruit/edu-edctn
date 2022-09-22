namespace Portal.UI_MVC_Web.Controllers
{
    [Authorize]
    public class PerkController : Controller
    {
        private readonly IPerkService _perkService;

        public PerkController(IPerkService perkService)
        {
            _perkService = perkService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await GetPerkIndexModel());
        }

        public async Task<IActionResult> AddOrEdit(int? id)
        {
            PerkDTO perk;

            if (id == null)
            {
                perk = new PerkDTO();
            }
            else
            {
                perk = await _perkService.GetById(id.Value);
            }

            return View(perk);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrEdit(PerkDTO perk)
        {
            if (!ModelState.IsValid)
            {
                return View(perk);
            }

            if (perk.Id.Equals(default))
            {
                await _perkService.Create(perk);
            }
            else
            {
                await _perkService.Update(perk);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _perkService.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return PartialView("_PerkPartial", await GetPerkIndexModel());
        }

        private async Task<PerkIndexModel> GetPerkIndexModel()
        {
            var articles = await _perkService.GetAll();

            return new PerkIndexModel(articles);
        }
    }
}

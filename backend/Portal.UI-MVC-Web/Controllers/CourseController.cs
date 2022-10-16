namespace Portal.UI_MVC_Web.Controllers
{
    [Authorize]
    public class CourseController : BaseController
    {
        private readonly ICourseViewModelService _viewModelService;

        public CourseController(ICourseViewModelService viewModelService, IUserService userService)
            : base(userService)
        {
            _viewModelService = viewModelService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _viewModelService.GetCourseIndexModel());
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _viewModelService.ToCourseViewModelById(id);

            await IfLoggedPutUser(model);

            return View(model);
        }

        public async Task<IActionResult> AddOrEdit(int? id)
        {
            if (id != null)
            {
                return View(await _viewModelService.ToCourseViewModelByIdWithUnmarked(id.Value));
            }

            return View(await _viewModelService.ToCourseViewModelWithUnmarked(new CourseDTO()));
        }

        [HttpPost]
        public async Task<IActionResult> AddOrEdit(CourseViewModel courseViewModel)
        {
            if (courseViewModel.Id.Equals(default))
            {
                await _viewModelService.CallCreateCourse(courseViewModel);
            }
            else
            {
                await _viewModelService.CallUpdateCourse(courseViewModel);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _viewModelService.CallDeleteCourse(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return PartialView("_CoursePartial", await _viewModelService.GetCourseIndexModel());
        }

        private async Task IfLoggedPutUser(CourseViewModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                model.LoggedUser = await GetUserByLoggedEmail();
            }
        }
    }
}
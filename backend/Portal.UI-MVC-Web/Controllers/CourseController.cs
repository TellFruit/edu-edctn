﻿namespace Portal.UI_MVC_Web.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly ICourseViewModelService _viewModelService;

        public CourseController(ICourseViewModelService viewModelService)
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
            return View(await _viewModelService.ToCourseViewModelById(id));
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
            if (!ModelState.IsValid)
            {
                return View(courseViewModel);
            }

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
    }
}

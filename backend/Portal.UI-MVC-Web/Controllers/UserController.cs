namespace Portal.UI_MVC_Web.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly ICourseViewModelService _viewModelService;
        private readonly IUserService _userService;
        private readonly IRuleUser _ruleUser;

        public UserController(IUserService userService, IRuleUser ruleUser, ICourseViewModelService viewModelService)
            : base(userService)
        {
            _viewModelService = viewModelService;
            _userService = userService;
            _ruleUser = ruleUser;
        }

        public async Task<IActionResult> Info()
        {
            return View(await GetUserByLoggedEmail());
        }

        public async Task<IActionResult> UpdateInfo(UserDTO user)
        {
            await _userService.Update(user);

            if (User.Identity.Name.Equals(user.Email) is false)
            {
                return RedirectToAction("Login", "Auth");
            }

            return RedirectToAction(nameof(Info));
        }

        public async Task<IActionResult> Enroll(int courseId)
        {
            var user = await GetUserByLoggedEmail();

            await _ruleUser.Enroll(user.Id, courseId);

            return RedirectToAction("Index", "Course");
        }

        public async Task<IActionResult> Unenroll(int courseId)
        {
            var user = await GetUserByLoggedEmail();

            await _ruleUser.Unenroll(user.Id, courseId);

            return RedirectToAction("Index", "Course");
        }

        public async Task<IActionResult> Courses()
        {
            var model = await _viewModelService.GetCourseIndexModel();

            var user = await GetUserByLoggedEmail();

            var ids = user.CourseProgress.Select(c => c.CourseId).ToList();

            model.Courses = model.Courses.Where(c => ids.Contains(c.Id)).ToList();

            model.LoggedUser = user;

            return View(model);
        }
    }
}
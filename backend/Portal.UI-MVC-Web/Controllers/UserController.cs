namespace Portal.UI_MVC_Web.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IAttendViewModelService _viewModelService;
        private readonly IUserService _userService;
        private readonly IRuleUser _ruleUser;

        public UserController(IUserService userService, IRuleUser ruleUser, IAttendViewModelService viewModelService)
            : base(userService)
        {
            _userService = userService;
            _ruleUser = ruleUser;
            _viewModelService = viewModelService;
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
            _viewModelService.SetUser(await GetUserByLoggedEmail());

            return View(await _viewModelService.GetAttendedCourses());
        }

        public async Task<IActionResult> Attend(int courseId)
        {
            _viewModelService.SetUser(await GetUserByLoggedEmail());

            return View(await _viewModelService.GetAttendModelById(courseId));
        }

        [HttpPost]
        public async Task LearnMaterial(int materialId)
        {
            var user = await GetUserByLoggedEmail();

            _viewModelService.SetUser(user);

            await _ruleUser.MarkLearned(user.Id, materialId);
        }
    }
}
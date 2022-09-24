namespace Portal.UI_MVC_Web.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IRuleUser _ruleUser;

        public UserController(IUserService userService, IRuleUser ruleUser)
            : base(userService)
        {
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

        public async Task<IActionResult> EnrollInCourse(int courseId)
        {
            var user = await GetUserByLoggedEmail();

            await _ruleUser.Enroll(user.Id, courseId);

            return RedirectToAction("Index", "Course");
        }
    }
}
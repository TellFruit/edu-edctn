namespace Portal.UI_MVC_Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Info()
        {
            var spec = new UserByEmailSpec(HttpContext.Session.GetString("LoggedEmail"));

            var user = await _userService.GetBySpec(spec);

            return View(user.First());
        }

        public async Task<IActionResult> UpdateInfo(UserDTO user)
        {
            await _userService.Update(user);

            HttpContext.Session.SetString("LoggedEmail", user.Email);

            return RedirectToAction(nameof(Info));
        }
    }
}
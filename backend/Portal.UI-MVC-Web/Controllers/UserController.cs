using Portal.Domain.Entities.User.Specification;

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
            var spec = new UserByEmailSpec(User.Identity.Name);

            var user = await _userService.GetBySpec(spec);

            return View(user);
        }
    }
}

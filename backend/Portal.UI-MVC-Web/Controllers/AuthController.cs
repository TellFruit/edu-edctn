using Portal.UI_MVC_Web.Models.Auth;

namespace Portal.UI_MVC_Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserAuth _userAuth;

        public AuthController(IUserAuth userAuth)
        {
            _userAuth = userAuth;
        }

        public IActionResult Login(AuthModel model)
        {
            return View(model);
        }

        public IActionResult Register(AuthModel model)
        {
            return View(model);
        }
    }
}

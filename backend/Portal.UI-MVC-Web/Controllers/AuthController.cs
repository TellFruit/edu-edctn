namespace Portal.UI_MVC_Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserAuth _userAuth;
        private readonly IUserService _userService;

        public AuthController(IUserAuth userAuth, IUserService userService)
        {
            _userAuth = userAuth;
            _userService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var loggedId = await _userAuth.Login(model.Email, model.Password);

            if (loggedId.Equals(default))
            {
                return View();
            }

            var loggedUser = await _userService.GetById(loggedId);
            
            await Authenticate(loggedUser.Email, loggedUser.Role.ToString());

            return RedirectBack();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            await _userAuth.Register(model.Email, model.Password);

            await Authenticate(model.Email, Roles.Learner.ToString());

            return RedirectBack();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        private async Task Authenticate(string userName, string userRole)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, userRole)
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));
        }

        private IActionResult RedirectBack()
        {
            var previousUrl = RetrievePreviousUrl();

            if (previousUrl.Equals(string.Empty))
            {
                return RedirectToAction("Index", "Home");
            }

            return Redirect(previousUrl);
        }

        private string RetrievePreviousUrl()
        {
            return HttpContext.Session.GetString("LastUrl") ?? string.Empty;
        }
    }
}

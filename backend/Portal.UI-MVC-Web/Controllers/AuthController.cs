namespace Portal.UI_MVC_Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserAuth _userAuth;

        public AuthController(IUserAuth userAuth)
        {
            _userAuth = userAuth;
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
            
            await Authenticate(model.Email);

            return RedirectBack();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var loggedId = await _userAuth.Register(model.Email, model.Password);

            if (loggedId.Equals(default))
            {
                return View();
            }

            await Authenticate(model.Email);

            return RedirectBack();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName)
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

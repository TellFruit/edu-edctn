namespace Portal.UI_MVC_Web.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IUserAuth _userAuth;

        public AuthController(IUserAuth userAuth) : base(userAuth) 
        {
            _userAuth = userAuth;
        }

        public IActionResult Login(string returnController, string returnAction, object? returnModel)
        {
            if (IsTempDataAuthorazied())
            {
                return RedirectHome();
            }

            var model = new AuthModel()
            {
                User = new UserDTO(),
                ReturnController = returnController,
                ReturnAction = returnAction,
                ReturnModel = returnModel
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthModel model)
        {
            if (IsTempDataAuthorazied())
            {
                return RedirectHome();
            }

            int loggedId = await _userAuth.Login(model.User.Email, model.User.Password);

            if (_userAuth.IsAuthorized(loggedId))
            {
                TempData[nameof(_userAuth.IsAuthorized)] = loggedId;

                return RedirectBack(model);
            }

            return View(model);
        }

        public IActionResult Register(AuthModel model)
        {
            return View(model);
        }

        private IActionResult RedirectBack(AuthModel model)
        {
            return RedirectToAction(model.ReturnAction, model.ReturnController, model.ReturnModel);
        }
    }
}

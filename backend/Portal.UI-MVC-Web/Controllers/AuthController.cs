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

            var model = new CallbackModel()
            {
                ReturnController = returnController,
                ReturnAction = returnAction,
                ReturnModel = returnModel
            };

            //TempData[nameof(CallbackModel)] = model;

            return View(new UserDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserDTO user)
        {
            if (IsTempDataAuthorazied())
            {
                return RedirectHome();
            }

            var callback = TempData[nameof(CallbackModel)] as CallbackModel;

            int loggedId = await _userAuth.Login(user.Email, user.Password);

            if (_userAuth.IsAuthorized(loggedId))
            {
                TempData[nameof(_userAuth.IsAuthorized)] = loggedId;

                return RedirectBack(callback);
            }

            return View(callback);
        }

        public IActionResult Register(CallbackModel model)
        {
            return View(model);
        }

        private IActionResult RedirectBack(CallbackModel model)
        {
            return RedirectToAction(model.ReturnAction, model.ReturnController, model.ReturnModel);
        }
    }
}

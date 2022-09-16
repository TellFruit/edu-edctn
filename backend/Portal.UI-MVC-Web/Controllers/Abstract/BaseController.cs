namespace Portal.UI_MVC_Web.Controllers.Abstract
{
    public abstract class BaseController : Controller
    {
        private readonly IUserAuth _userAuth;

        public BaseController(IUserAuth userAuth)
        {
            _userAuth = userAuth;
        }

        protected bool IsTempDataAuthorazied()
        {
            int loggedId = (int?)TempData[nameof(_userAuth.IsAuthorized)] ?? default;

            return _userAuth.IsAuthorized(loggedId);
        }

        protected IActionResult RedirectLogin(RouteValueDictionary routeValues, object? returnModel)
        {
            return RedirectToAction("Login", "Auth",
                new
                { 
                    returnController = routeValues["controller"],
                    returnAction = routeValues["action"],
                    returnModel = returnModel,
                });
        }

        protected IActionResult RedirectHome()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}

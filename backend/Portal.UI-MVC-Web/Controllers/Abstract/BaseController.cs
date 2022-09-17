namespace Portal.UI_MVC_Web.Controllers.Abstract
{
    public abstract class BaseController : Controller
    {
        private readonly IUserAuth _userAuth;

        public BaseController(IUserAuth userAuth)
        {
            _userAuth = userAuth;
        }
    }
}

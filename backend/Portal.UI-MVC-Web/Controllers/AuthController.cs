namespace Portal.UI_MVC_Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserAuth _userAuth;

        public AuthController(IUserAuth userAuth)
        {
            _userAuth = userAuth;
        }


    }
}

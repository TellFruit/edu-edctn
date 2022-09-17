namespace Portal.UI_MVC_Web.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IUserAuth _userAuth;
        private readonly ISerialize _serialize;

        public AuthController(IUserAuth userAuth, ISerialize serialize) : base(userAuth)
        {
            _userAuth = userAuth;
            _serialize = serialize;
        }
    }
}

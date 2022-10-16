namespace Portal.UI_MVC_Web.Controllers.Abstract
{
    public class BaseController : Controller
    {
        private readonly IUserService _userService;

        public BaseController(IUserService userService)
        {
            _userService = userService;
        }

        protected async Task<UserDTO> GetUserByLoggedEmail()
        {
            var spec = new UserByEmailSpec(User.Identity.Name);

            var user = await _userService.GetBySpec(spec);

            return user.First();
        }
    }
}

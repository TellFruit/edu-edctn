namespace Portal.UI_MVC_Web.Models.Auth
{
    public class AuthModel
    {
        public UserDTO User { get; set; }
        public RouteValueDictionary ReturnRoutes { get; set; }
        public object ReturnModel { get; set; }
    }
}

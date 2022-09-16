namespace Portal.UI_MVC_Web.Models.Auth
{
    public class CallbackModel
    {
        public string ReturnController { get; set; }
        public string ReturnAction { get; set; }
        public object? ReturnModel { get; set; }
    }
}

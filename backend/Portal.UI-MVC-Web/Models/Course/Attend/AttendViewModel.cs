namespace Portal.UI_MVC_Web.Models.Course.Attend
{
    public class AttendViewModel
    {
        public CourseDTO Course { get; set; }

        public UserDTO User { get; set; }

        public IList<AttendMaterialModel> Materials { get; set; }
    }
}

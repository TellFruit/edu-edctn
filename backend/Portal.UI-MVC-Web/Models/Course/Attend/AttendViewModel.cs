namespace Portal.UI_MVC_Web.Models.Course.Attend
{
    public class AttendViewModel
    {
        public CourseDTO Course { get; set; }

        public UserDTO UserDTO { get; set; }

        public ICollection<AttendMaterialModel> Materials { get; set; }
    }
}

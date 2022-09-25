namespace Portal.UI_MVC_Web.Models.Course
{
    public class CourseIndexModel
    {
        public UserDTO LoggedUser { get; set; }

        public ICollection<CourseDTO> Courses { get; set; }

        public CourseIndexModel(ICollection<CourseDTO> courses)
        {
            Courses = courses;
        }
    }
}

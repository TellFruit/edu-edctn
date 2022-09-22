namespace Portal.UI_MVC_Web.Models.Course
{
    public class CourseIndexModel
    {
        ICollection<CourseDTO> _courses;

        public CourseIndexModel(ICollection<CourseDTO> courses)
        {
            _courses = courses;
        }
    }
}

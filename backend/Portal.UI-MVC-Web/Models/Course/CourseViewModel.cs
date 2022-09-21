namespace Portal.UI_MVC_Web.Models.Course
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<CourseArticleModel> Articles { get; set; }

        public CourseViewModel()
        {
            Articles = new List<CourseArticleModel>();
        }
    }
}

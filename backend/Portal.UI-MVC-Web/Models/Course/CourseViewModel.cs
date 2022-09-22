namespace Portal.UI_MVC_Web.Models.Course
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<CourseArticleModel> Articles { get; set; }
        public IList<CourseBookModel> Books { get; set; }
        public IList<CourseVideoModel> Videos { get; set; }
        public IList<CoursePerkModel> Perks { get; set; }

        public CourseViewModel()
        {
            Articles = new List<CourseArticleModel>();
            Books = new List<CourseBookModel>();
            Videos = new List<CourseVideoModel>();
            Perks = new List<CoursePerkModel>();
        }
    }
}

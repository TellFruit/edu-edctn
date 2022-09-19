using Portal.UI_MVC_Web.Models.Course;

namespace Portal.UI_MVC_Web.Interfaces
{
    public interface IModifyCourseViewModel
    {
        public void SetHttpContext(HttpContext context);

        public void SetModelFromDTO(CourseDTO courseDTO);

        public void AddArticle(int id);

        public void RemoveArticle(int id);

        public ModifyCourseModel GetModel();
    }
}

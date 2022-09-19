namespace Portal.UI_MVC_Web.Models.Course
{
    public class ChooseArticleModel
    {
        public ICollection<ArticleDTO> UnmarkedArticles { get; set; }

        public ICollection<ArticleDTO> MarkedArticles { get; set; }
    }
}

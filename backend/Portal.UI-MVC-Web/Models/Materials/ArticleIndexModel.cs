namespace Portal.UI_MVC_Web.Models.Materials
{
    public class ArticleIndexModel
    {
        public ICollection<ArticleDTO> ArticleList { get; set; }

        public ArticleIndexModel(ICollection<ArticleDTO> articleList)
        {
            ArticleList = articleList;
        }
    }
}

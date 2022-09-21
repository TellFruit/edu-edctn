namespace Portal.Domain.Entities.Material.Specification
{
    public class ArticleByIdFilter : Specification<ArticleDomain>
    {
        private readonly int _articleId;

        public ArticleByIdFilter(int articleId)
        {
            _articleId = articleId;
        }

        public override bool IsSatisfiedBy(ArticleDomain item)
        {
            return item.Id.Equals(_articleId);
        }
    }
}

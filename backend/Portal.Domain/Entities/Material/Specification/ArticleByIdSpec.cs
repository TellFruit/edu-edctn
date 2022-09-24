namespace Portal.Domain.Entities.Material.Specification
{
    public class ArticleByIdSpec : Specification<ArticleDomain>
    {
        private readonly int _articleId;

        public ArticleByIdSpec(int articleId)
        {
            _articleId = articleId;
        }

        public override bool IsSatisfiedBy(ArticleDomain item)
        {
            return item.Id.Equals(_articleId);
        }
    }
}

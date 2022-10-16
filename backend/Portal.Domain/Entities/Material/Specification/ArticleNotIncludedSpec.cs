namespace Portal.Domain.Entities.Material.Specification
{
    public class ArticleNotIncludedSpec : Specification<ArticleDomain>
    {
        private IEnumerable<int> _ids;

        public ArticleNotIncludedSpec(IEnumerable<int> ids)
        {
            _ids = ids;
        }

        public override bool IsSatisfiedBy(ArticleDomain item)
        {
            return _ids.Contains(item.Id) is false;
        }
    }
}

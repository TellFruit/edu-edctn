using Portal.Domain.GenericSpecification;

namespace Portal.Domain.Entities.Material.Specification
{
    public class ArticleIdFilter : Specification<ArticleDomain>
    {
        private ICollection<int> _ids;

        public ArticleIdFilter(ICollection<int> ids)
        {
            _ids = ids;
        }

        public override bool IsSatisfiedBy(ArticleDomain item)
        {
            return _ids.Contains(item.Id);
        }
    }
}

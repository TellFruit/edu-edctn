namespace Portal.Domain.Entities.Material.Specification
{
    public class BookNotIncludedSpec : Specification<BookDomain>
    {
        private IEnumerable<int> _ids;

        public BookNotIncludedSpec(IEnumerable<int> ids)
        {
            _ids = ids;
        }

        public override bool IsSatisfiedBy(BookDomain item)
        {
            return _ids.Contains(item.Id) is false;
        }
    }
}

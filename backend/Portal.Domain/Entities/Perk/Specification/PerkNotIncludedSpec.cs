namespace Portal.Domain.Entities.Perk.Specification
{
    public class PerkNotIncludedSpec : Specification<PerkDomain>
    {
        private IEnumerable<int> _ids;

        public PerkNotIncludedSpec(IEnumerable<int> ids)
        {
            _ids = ids;
        }

        public override bool IsSatisfiedBy(PerkDomain item)
        {
            return _ids.Contains(item.Id) is false;
        }
    }
}

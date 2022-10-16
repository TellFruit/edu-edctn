namespace Portal.Domain.Entities.Material.Specification
{
    public class VideoNotIncludedSpec : Specification<VideoDomain>
    {
        private IEnumerable<int> _ids;

        public VideoNotIncludedSpec(IEnumerable<int> ids)
        {
            _ids = ids;
        }

        public override bool IsSatisfiedBy(VideoDomain item)
        {
            return _ids.Contains(item.Id) is false;
        }
    }
}
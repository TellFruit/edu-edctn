namespace Portal.Domain.Entities.Course.Specification
{
    public class CourseIncludedSpec : Specification<CourseDomain>
    {
        private IEnumerable<int> _ids;

        public CourseIncludedSpec(IEnumerable<int> ids)
        {
            _ids = ids;
        }

        public override bool IsSatisfiedBy(CourseDomain item)
        {
            return _ids.Contains(item.Id);
        }
    }
}

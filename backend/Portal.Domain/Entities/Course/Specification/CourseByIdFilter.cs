namespace Portal.Domain.Entities.Course.Specification
{
    public class CourseByIdFilter : Specification<CourseDomain>
    {
        private readonly int _courseId;

        public CourseByIdFilter(int courseId)
        {
            _courseId = courseId;
        }

        public override bool IsSatisfiedBy(CourseDomain item)
        {
            return item.Id.Equals(_courseId);
        }
    }
}

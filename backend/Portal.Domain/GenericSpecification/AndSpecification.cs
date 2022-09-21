using Portal.Domain.Entities.Abstract;

namespace Portal.Domain.GenericSpecification
{
    internal class AndSpecification<T> : Specification<T> where T : BaseEntity
    {
        private ISpecification<T> leftSpec;
        private ISpecification<T> rightSpec;

        public AndSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            leftSpec = first;
            rightSpec = second;
        }

        public override bool IsSatisfiedBy(T item)
        {
            return leftSpec.IsSatisfiedBy(item) 
                && rightSpec.IsSatisfiedBy(item);
        }
    }
}
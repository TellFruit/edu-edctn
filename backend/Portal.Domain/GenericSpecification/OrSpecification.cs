using Portal.Domain.Entities.Abstract;
using Portal.Domain.Interfaces;

namespace Portal.Domain.GenericSpecification
{
    internal class OrSpecification<T> : Specification<T> where T : BaseEntity
    {
		private ISpecification<T> leftSpec;
		private ISpecification<T> rightSpec;

		public OrSpecification(ISpecification<T> first, ISpecification<T> second)
		{
			leftSpec = first;
			rightSpec = second;
		}

		public override bool IsSatisfiedBy(T item)
		{
			return leftSpec.IsSatisfiedBy(item)
				|| rightSpec.IsSatisfiedBy(item);
		}
	}
}
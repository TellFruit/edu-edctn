using Portal.Domain.Entities.Abstract;
using Portal.Domain.Interfaces;

namespace Portal.Domain.GenericSpecification
{
    internal class NotSpecification<T> : Specification<T> where T : BaseEntity
    {
		private ISpecification<T> specification;

		public NotSpecification(ISpecification<T> spec)
		{
			specification = spec;
		}

		public override bool IsSatisfiedBy(T item)
		{
			return specification.IsSatisfiedBy(item) is false;
		}
	}
}
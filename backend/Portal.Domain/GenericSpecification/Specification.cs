using Portal.Domain.Entities.Abstract;
using Portal.Domain.Interfaces;

namespace Portal.Domain.GenericSpecification
{
    public abstract class Specification<T> : ISpecification<T> where T : BaseEntity
    {
		public abstract bool IsSatisfiedBy(T item);

		public ISpecification<T> And(ISpecification<T> specification)
		{
			return new AndSpecification<T>(this, specification);
		}

		public ISpecification<T> Or(ISpecification<T> specification)
		{
			return new OrSpecification<T>(this, specification);
		}

		public ISpecification<T> Not(ISpecification<T> specification)
		{
			return new NotSpecification<T>(specification);
		}
	}
}

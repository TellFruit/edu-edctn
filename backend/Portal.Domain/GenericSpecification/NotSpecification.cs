namespace Portal.Domain.GenericSpecification
{
    internal class NotSpecification<T> : Specification<T> where T : BaseEntity
    {
		private ISpecification<T> _specification;

		public NotSpecification(ISpecification<T> spec)
		{
			_specification = spec;
		}

		public override bool IsSatisfiedBy(T item)
		{
			return _specification.IsSatisfiedBy(item) is false;
		}
	}
}
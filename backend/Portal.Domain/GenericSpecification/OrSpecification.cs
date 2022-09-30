namespace Portal.Domain.GenericSpecification
{
    internal class OrSpecification<T> : Specification<T> where T : BaseEntity
    {
		private ISpecification<T> _leftSpec;
		private ISpecification<T> _rightSpec;

		public OrSpecification(ISpecification<T> first, ISpecification<T> second)
		{
			_leftSpec = first;
			_rightSpec = second;
		}

		public override bool IsSatisfiedBy(T item)
		{
			return _leftSpec.IsSatisfiedBy(item)
				|| _rightSpec.IsSatisfiedBy(item);
		}
	}
}
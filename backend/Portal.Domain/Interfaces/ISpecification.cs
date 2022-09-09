using Portal.Domain.Entities.Abstract;

namespace Portal.Domain.Interfaces
{
    public interface ISpecification<T> where T : BaseEntity
    {
        bool IsSatisfiedBy(T item);

        ISpecification<T> And(ISpecification<T> specification);

        ISpecification<T> Or(ISpecification<T> specification);

        ISpecification<T> Not(ISpecification<T> specification);
    }
}

using Portal.Domain.Entities.Abstract;
using Portal.Domain.Interfaces;

namespace Portal.Domain.GenericSpecification
{
    internal class AndSpecification<T> : ISpecification<T> where T : BaseEntity
    {
    }
}
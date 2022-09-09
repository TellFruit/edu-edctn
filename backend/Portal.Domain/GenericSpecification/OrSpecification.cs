using Portal.Domain.Entities.Abstract;
using Portal.Domain.Interfaces;

namespace Portal.Domain.GenericSpecification
{
    internal class OrSpecification<T> : ISpecification<T> where T : BaseEntity
    {
    }
}
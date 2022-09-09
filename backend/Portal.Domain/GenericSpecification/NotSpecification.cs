using Portal.Domain.Entities.Abstract;
using Portal.Domain.Interfaces;

namespace Portal.Domain.GenericSpecification
{
    internal class NotSpecification<T> : ISpecification<T> where T : BaseEntity
    {
    }
}
namespace Portal.Domain.GenericSpecification
{
    public static class SpecificationExtension
    {
        public static ICollection<T> Where<T>(this ICollection<T> collection,
            ISpecification<T> specification) where T : BaseEntity
        {
            return collection
                .Where(e => specification.IsSatisfiedBy(e))
                .ToList();
        }

        public static T? FirstOrDefault<T>(this ICollection<T> collection,
            ISpecification<T> specification) where T : BaseEntity
        {
            return collection.FirstOrDefault(e => specification.IsSatisfiedBy(e));
        }
    }
}

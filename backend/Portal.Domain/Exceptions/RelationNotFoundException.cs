namespace Portal.Domain.Exceptions
{
    public class RelationNotFoundException : Exception
    {
        public RelationNotFoundException(string name)
            : base($"Relation named ({name}) not found!") { }
    }
}

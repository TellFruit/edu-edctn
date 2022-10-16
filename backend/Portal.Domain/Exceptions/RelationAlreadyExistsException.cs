namespace Portal.Domain.Exceptions
{
    public class RelationAlreadyExistsException : Exception
    {
        public RelationAlreadyExistsException(string name)
            : base($"Relation named ({name}) already exists!") { }
    }
}

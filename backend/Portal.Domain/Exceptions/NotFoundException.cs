namespace Portal.Domain.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string name)
            : base($"Entity named ({name}) not found!"){}
    }
}

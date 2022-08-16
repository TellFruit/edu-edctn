namespace Portal.Persistence_EF_Core.Exceptions
{
    internal class DbEntityNotFoundException : Exception
    {
        public DbEntityNotFoundException(string type)
            : base($"Database entity of type ({type}) not found!") { }
    }
}

namespace Portal.Domain.Interfaces
{
    internal interface ISerializationService
    {
        public T Deserialize<T>(string json);

        public string Serialize<T>(T obj);
    }
}

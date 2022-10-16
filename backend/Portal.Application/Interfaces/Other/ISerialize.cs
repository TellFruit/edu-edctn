namespace Portal.Application.Interfaces.Other
{
    public interface ISerialize
    {
        public T Deserialize<T>(string json);

        public string Serialize<T>(T obj);
    }
}

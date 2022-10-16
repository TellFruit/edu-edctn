namespace Portal.Application.Services.Config
{
    internal class SimpleJsonService : ISerialize
    {
        public T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json)
                ?? throw new ArgumentException(nameof(json));
        }

        public string Serialize<T>(T obj)
        {
            string result = JsonConvert.SerializeObject(obj);

            return result.Length > 0 ? result : throw new ArgumentException(nameof(obj));
        }
    }
}

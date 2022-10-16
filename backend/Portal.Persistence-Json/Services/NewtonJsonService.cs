namespace Portal.Persistence_Json.Services
{
    internal class NewtonJsonService : ISerializationService
    {
        private readonly JsonSerializerSettings _settings;

        public NewtonJsonService()
        {
            _settings = new JsonSerializerSettings {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented };
        }

        public T Deserialize<T>(string json)
        {
            return (T)JsonConvert.DeserializeObject(json, typeof(T), _settings)
                ?? throw new ArgumentException(nameof(json));
        }

        public string Serialize<T>(T obj)
        {
            string result = JsonConvert.SerializeObject(obj, _settings);

            return result.Length > 0 ? result : throw new ArgumentException(nameof(obj));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Persistence_Json.Services
{
    internal class JsonSerializationService : ISerializationService
    {
        public T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json) ?? throw new ArgumentException(nameof(json));
        }

        public string Serialize<T>(T obj)
        {
            string result = JsonConvert.SerializeObject(obj, Formatting.Indented);

            return result.Length > 1 ? result : throw new ArgumentException(nameof(obj));
        }
    }
}

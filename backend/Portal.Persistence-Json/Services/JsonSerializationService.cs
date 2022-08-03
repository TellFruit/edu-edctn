using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Persistence_Json.Services
{
    internal class JsonSerializationService : ISerializationService
    {
        public T Deserialize<T>(string serialized)
        {
            throw new NotImplementedException();
        }

        public string Serialize<T>(T unserialized)
        {
            throw new NotImplementedException();
        }
    }
}

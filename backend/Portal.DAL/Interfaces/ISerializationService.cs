using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Interfaces
{
    internal interface ISerializationService
    {
        string Serialize<T>(T obj);

        T Deserialize<T>(string json);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Interfaces
{
    public interface ISerializationService
    {
        // turn any object into a specified string
        string Serialize<T>(T unserialized);

        // make serialized string a specified object again 
        T Deserialize<T>(string serialized);
    }
}

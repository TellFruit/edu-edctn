namespace Portal.Domain.Interfaces
{
    internal interface ISerializationService
    {
        // turn any object into a specified string
        string Serialize<T>(T unserialized);

        // make serialized string a specified object again 
        T Deserialize<T>(string serialized);
    }
}

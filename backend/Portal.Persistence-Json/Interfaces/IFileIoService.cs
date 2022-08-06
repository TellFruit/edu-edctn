namespace Portal.Domain.Interfaces
{
    internal interface IFileIoService
    {
        void Write(string data);

        string Read();

        IFileIoService SetPath(string path);
    }
}

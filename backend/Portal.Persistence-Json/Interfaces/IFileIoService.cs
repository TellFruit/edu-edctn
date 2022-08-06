namespace Portal.Domain.Interfaces
{
    public interface IFileIoService
    {
        void Write(string data);

        string Read();

        IFileIoService SetPath(string path);
    }
}

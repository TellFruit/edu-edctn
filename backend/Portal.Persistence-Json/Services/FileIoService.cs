namespace Portal.Persistence_Json.Services
{
    internal class FileIoService : IFileIoService
    {
        private string _path;

        public string Read()
        {
            string result = "";

            if (File.Exists(_path))
            {
                using (StreamReader reader = new StreamReader(_path))
                {
                    result = reader.ReadToEnd();
                }
            }
            else
            {
                throw new FileNotFoundException(nameof(_path));
            }

            return result;
        }

        public void Write(string data)
        {
            using (StreamWriter writer = new StreamWriter(_path, false))
            {
                writer.Write(data);
            }
        }

        public IFileIoService SetPath(string path)
        {
            _path = path;

            return this;
        }
    }
}

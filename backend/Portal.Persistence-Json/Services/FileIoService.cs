using Portal.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Persistence_Json.Services
{
    internal class FileIoService : IFileIoService
    {
        private string _path;

        public FileIoService(string path)
        {
            _path = path;
        }

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
    }
}

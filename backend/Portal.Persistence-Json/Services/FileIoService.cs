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
            throw new NotImplementedException();
        }

        public void Write(string data)
        {
            throw new NotImplementedException();
        }
    }
}

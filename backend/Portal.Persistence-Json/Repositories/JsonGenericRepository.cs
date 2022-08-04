using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Persistence_Json.Repositories
{
    internal class JsonGenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly IFileIoService _file;
        private readonly ISerializationService _json;

        private ICollection<T> _entities;

        public JsonGenericRepository(IFileIoService file, ISerializationService json)
        {
            _file = file;
            _json = json;

            InitEntities();
        }

        public void Create(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<T> Read()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        private void InitEntities()
        {
            try
            {
                _entities = _json.Deserialize<List<T>>(_file.Read());
            }
            catch (ArgumentException)
            {
                _entities = new List<T>();
            }
        }
    }
}

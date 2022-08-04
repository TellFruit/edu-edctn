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
            _entities.Add(entity);
        }

        public void Delete(T entity)
        {
            _entities.Remove(entity);
        }

        public ICollection<T> Read()
        {
            return _entities;
        }

        public void Update(T entity)
        {
            var match = _entities.FirstOrDefault(e => e.Id.Equals(entity.Id));

            if (match is not null)
            {
                Delete(match);
                Create(entity);
            }
        }
        public void SaveChanges()
        {
            var type = typeof(T);
            string path = $"{Directory.GetCurrentDirectory}\\{nameof(type.Name)}\\.json";
            _file.SetPath(path).Write(_json.Serialize(_entities));
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

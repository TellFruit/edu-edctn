namespace Portal.Persistence_Json.Repositories
{
    internal class JsonGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IFileIoService _file;
        private readonly ISerializationService _json;

        private string _path;

        private ICollection<TEntity> _entities;

        public JsonGenericRepository(IFileIoService file, ISerializationService json)
        {
            _file = file;
            _json = json;

            _path = GeneratePath();
            _file.SetPath(_path);
            InitEntities();
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            entity.Id = GenerateNextId();
            _entities.Add(entity);

            return entity;
        }

        public async Task<int> Delete(TEntity entity)
        {
            _entities.Remove(_entities.FirstOrDefault(e => e.Id == entity.Id));

            return entity.Id;
        }

        public async Task<ICollection<TEntity>> Read()
        {
            return _entities;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            var match = _entities.FirstOrDefault(e => e.Id.Equals(entity.Id));

            if (match is not null)
            {
                Delete(match);
                Create(entity);
            }

            return entity;
        }

        public async Task SaveChanges()
        {
            _file.SetPath(_path).Write(_json.Serialize(_entities));
        }

        private void InitEntities()
        {
            try
            {
                _entities = _json.Deserialize<List<TEntity>>(_file.Read());
            }
            catch (ArgumentException)
            {
                _entities = new List<TEntity>();
            }
        }

        private int GenerateNextId()
        {
            int result = 1;

            if (_entities.Count > 0)
            {
                result = _entities.Max(b => b.Id) + 1;
            }

            return result;
        }

        private string GeneratePath()
        {
            return $"{Environment.CurrentDirectory}\\{typeof(TEntity).Name}.json";
        }
    }
}

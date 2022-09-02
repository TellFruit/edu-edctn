namespace Portal.Persistence_EF_Core.Repositories
{
    internal class VideoRepository : BaseRepository, IGenericRepository<VideoDomain>
    {
        public VideoRepository(IMapper mapper, PortalContext context) 
            : base(mapper, context) {}

        public async Task<VideoDomain> Create(VideoDomain entity)
        {
            var videoEntity = _mapper.Map<Video>(entity);

            _context.Add(videoEntity);

            return entity;
        }

        public async Task<int> Delete(VideoDomain entity)
        {
            var videoEntity = GetById(entity.Id);

            if (videoEntity == null)
            {
                throw new DbEntityNotFoundException(nameof(Video));
            }

            _context.Materials.Remove(videoEntity);
            return videoEntity.Id;
        }

        public async Task<ICollection<VideoDomain>> Read()
        {
            var videos = _context.Materials.OfType<Video>().ToList();

            return videos.Select(x => _mapper.Map<VideoDomain>(x)).ToList();
        }

        public async Task<ICollection<VideoDomain>> Read(Func<VideoDomain, bool> predicate)
        {
            var res = await Read();

            return res.Where(predicate).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task<VideoDomain> Update(VideoDomain entity)
        {
            var videoEntity = GetById(entity.Id);

            if (videoEntity == null)
            {
                throw new DbEntityNotFoundException(nameof(Video));
            }

            videoEntity.Title = data.Title;
            videoEntity.Duration = data.Duration;
            videoEntity.Quality = data.Quality;
            videoEntity.UpdatedAt = data.UpdatedAt;

            _context.Materials.Update(videoEntity);

            return entity;
        }

        private Video GetById(int id)
        {
            return _context.Materials.OfType<Video>()
                .First(u => u.Id == id);
        }
    }
}

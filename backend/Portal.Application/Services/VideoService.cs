namespace Portal.Application.Services
{
    internal class VideoService : BaseModelService<VideoDomain>, IVideoService
    {
        private readonly AbstractValidator<VideoDTO> _validator;

        public VideoService(IGenericRepository<VideoDomain> repository, IMapper mapper, AbstractValidator<VideoDTO> validator)
            : base(repository, mapper)
        {
            _validator = validator;
        }

        public async Task<VideoDTO> Create(VideoDTO entity)
        {
            if (entity.Validate(_validator) is false)
            {
                return new VideoDTO();
            }

            var video = _mapper.Map<VideoDomain>(entity);

            video.CreatedAt = DateTime.Now;
            video.UpdatedAt = DateTime.Now;

            await _repository.Create(video);
            _repository.SaveChanges();

            return _mapper.Map<VideoDTO>(video);
        }

        public async Task<int> Delete(int id)
        {
            var videos = await _repository.Read();
            var toDelete = videos.FirstOrDefault(a => a.Id.Equals(id));

            if (toDelete is null)
            {
                throw new EntityNotFoundException(nameof(VideoDomain));
            }

            int result = await _repository.Delete(toDelete);
            _repository.SaveChanges();

            return result;
        }

        public async Task<ICollection<VideoDTO>> GetAll()
        {
            var videos = await _repository.Read();

            return _mapper.Map<ICollection<VideoDTO>>(videos);
        }

        public async Task<VideoDTO> GetById(int id)
        {
            var videos = await _repository.Read();

            var wantedVideo = videos.FirstOrDefault(v => v.Id.Equals(id));

            return _mapper.Map<VideoDTO>(wantedVideo);
        }

        public async Task<ICollection<VideoDTO>> GetBySpec(ISpecification<VideoDomain> specification)
        {
            var videos = await _repository.Read(specification);

            return _mapper.Map<ICollection<VideoDTO>>(videos);
        }

        public async Task<VideoDTO> Update(VideoDTO entity)
        {
            if (entity.Validate(_validator) is false)
            {
                return new VideoDTO();
            }

            var articles = await _repository.Read();

            var toUpdate = articles.FirstOrDefault(a => a.Id.Equals(entity.Id));
            var data = _mapper.Map<VideoDomain>(entity);

            if (toUpdate is null)
            {
                throw new EntityNotFoundException(nameof(VideoDomain));
            }

            toUpdate.Title = data.Title;
            toUpdate.Duration = data.Duration;
            toUpdate.Quality = data.Quality;

            toUpdate.UpdatedAt = DateTime.Now;

            await _repository.Update(toUpdate);
            _repository.SaveChanges();

            return _mapper.Map<VideoDTO>(toUpdate);
        }
    }
}

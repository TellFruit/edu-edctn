﻿namespace Portal.Application.Services
{
    internal class VideoService : BaseModelService<Video>, IModelService<VideoDTO>
    {
        public VideoService(IGenericRepository<Video> repository, IMapper mapper)
            : base(repository, mapper) {}

        public async Task<VideoDTO> Create(VideoDTO entity)
        {
            var video = _mapper.Map<Video>(entity);

            video.CreatedAt = DateTime.Now;

            await _repository.Create(video);
            await _repository.SaveChanges();

            return _mapper.Map<VideoDTO>(video);
        }

        public async Task<int> Delete(int id)
        {
            var videos = await _repository.Read();
            var toDelete = videos.FirstOrDefault(a => a.Id.Equals(id));

            if (toDelete is null)
            {
                throw new EntityNotFoundException(nameof(Video));
            }

            return await _repository.Delete(toDelete);
        }

        public async Task<ICollection<VideoDTO>> GetAll()
        {
            var videos = await _repository.Read();

            return _mapper.Map<ICollection<VideoDTO>>(videos);
        }

        public async Task<VideoDTO> Update(VideoDTO entity)
        {
            var articles = await _repository.Read();

            var toUpdate = articles.FirstOrDefault(a => a.Id.Equals(entity.Id));
            var data = _mapper.Map<Video>(entity);

            if (toUpdate is null)
            {
                throw new EntityNotFoundException(nameof(Book));
            }

            toUpdate.Title = data.Title;
            toUpdate.Duration = data.Duration;
            toUpdate.Quality = data.Quality;
            toUpdate.Perks = data.Perks;

            toUpdate.UpdatedAt = DateTime.Now;

            await _repository.Update(toUpdate);

            return _mapper.Map<VideoDTO>(toUpdate);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Services
{
    internal class VideoService : BaseModelService<Video>, IModelService<VideoDTO>
    {
        public VideoService(IGenericRepository<Video> repository, IMapper mapper)
            : base(repository, mapper) {}

        public async Task<VideoDTO> Create(VideoDTO entity)
        {
            var video = _mapper.Map<Video>(entity);

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
            var articles = await _repository.Read();

            return _mapper.Map<ICollection<VideoDTO>>(articles);
        }

        public Task<VideoDTO> Update(VideoDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}

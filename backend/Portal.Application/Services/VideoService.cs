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

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<VideoDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<VideoDTO> Update(VideoDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}

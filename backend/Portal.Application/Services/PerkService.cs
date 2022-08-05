using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Services
{
    internal class PerkService : BaseModelService<Perk>, IModelService<PerkDTO>
    {
        public PerkService(IGenericRepository<Perk> repository, IMapper mapper)
            : base(repository, mapper) {}

        public async Task<PerkDTO> Create(PerkDTO entity)
        {
            var perk = _mapper.Map<Perk>(entity);

            perk.CreatedAt = DateTime.Now;

            await _repository.Create(perk);
            await _repository.SaveChanges();

            return _mapper.Map<PerkDTO>(perk);
        }

        public async Task<int> Delete(int id)
        {
            var perks = await _repository.Read();
            var toDelete = perks.FirstOrDefault(a => a.Id.Equals(id));

            if (toDelete is null)
            {
                throw new EntityNotFoundException(nameof(Perk));
            }

            return await _repository.Delete(toDelete);
        }

        public async Task<ICollection<PerkDTO>> GetAll()
        {
            var books = await _repository.Read();

            return _mapper.Map<ICollection<PerkDTO>>(books);
        }

        public Task<PerkDTO> Update(PerkDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}

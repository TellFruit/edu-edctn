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

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<PerkDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<PerkDTO> Update(PerkDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}

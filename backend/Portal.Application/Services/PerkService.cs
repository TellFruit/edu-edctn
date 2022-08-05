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

        public Task<PerkDTO> Create(PerkDTO entity)
        {
            throw new NotImplementedException();
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

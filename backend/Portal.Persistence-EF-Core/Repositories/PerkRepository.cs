using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Persistence_EF_Core.Repositories
{
    internal class PerkRepository : BaseRepository, IGenericRepository<PerkDomain>
    {
        public PerkRepository(IMapper mapper, PortalContext context) 
            : base(mapper, context) {}

        public Task<PerkDomain> Create(PerkDomain entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(PerkDomain entity)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<PerkDomain>> Read()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<PerkDomain> Update(PerkDomain entity)
        {
            throw new NotImplementedException();
        }
    }
}

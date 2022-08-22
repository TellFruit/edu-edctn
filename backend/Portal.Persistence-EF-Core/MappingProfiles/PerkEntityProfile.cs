using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Persistence_EF_Core.MappingProfiles
{
    public class PerkEntityProfile : Profile
    {
        public PerkEntityProfile()
        {
            CreateMap<PerkDomain, Perk>();

            CreateMap<Perk, PerkDomain>();
        }
    }
}

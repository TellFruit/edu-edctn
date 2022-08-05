using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.MappingProfiles
{
    internal class PerkProfile : Profile
    {
        public PerkProfile()
        {
            CreateMap<Perk, PerkDTO>();

            CreateMap<PerkDTO, Perk>();
        }
    }
}

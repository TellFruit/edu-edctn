using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.MappingProfiles
{
    public class MaterilProfile : Profile
    {
        public MaterilProfile()
        {
            CreateMap<Material, MaterialDTO>();

            CreateMap<MaterialDTO, Material>();
        }
    }
}

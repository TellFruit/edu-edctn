using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.MappingProfiles
{
    internal class ArticleProfile : Profile
    {
        public ArticleProfile(IMapper mapper)
        {
            CreateMap<Article, ArticleDTO>()
                .ForMember(a => a.Perks, src => src.MapFrom(a => a.Perks
                    .Select(x => mapper.Map<PerkDTO>(x))
                        .ToList()));

            CreateMap<ArticleDTO, Article>()
                .ForMember(a => a.Perks, src => src.MapFrom(a => a.Perks
                    .Select(x => mapper.Map<Perk>(x))
                        .ToList()));
        }
    }
}

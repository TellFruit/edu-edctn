using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.MappingProfiles
{
    internal class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleDTO>()
                .ForMember(a => a.Perks, opt => opt.MapFrom(src => src.Perks));

            CreateMap<ArticleDTO, Article>()
                .ForMember(a => a.Perks, opt => opt.MapFrom(src => src.Perks));
        }
    }
}

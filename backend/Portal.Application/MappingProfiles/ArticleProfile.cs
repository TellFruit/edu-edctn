using Portal.Domain.Entities.Material;

namespace Portal.Application.MappingProfiles
{
    internal class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticleDomain, ArticleDTO>()
                .IncludeBase<MaterialDomain, MaterialDTO>();

            CreateMap<ArticleDTO, ArticleDomain>()
                .IncludeBase<MaterialDTO, MaterialDomain>();
        }
    }
}

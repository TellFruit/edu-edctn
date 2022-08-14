using AutoMapper;
using Portal.Domain.Entities;
using Portal.Domain.Entities.Abstract;
using Portal.Persitence_EF_Core.FrameworkEntities;
using Portal.Persitence_EF_Core.FrameworkEntities.Abstract;

namespace Portal.Persistence_EF_Core.MappingProfiles
{
    internal class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticleDomain, Article>()
                .IncludeBase<MaterialDomain, Material>();

            CreateMap<Article, ArticleDomain>()
                .IncludeBase<Material, MaterialDomain>();
        }
    }
}

namespace Portal.Persistence_EF_Core.MappingProfiles
{
    internal class ArticleEntityProfile : Profile
    {
        public ArticleEntityProfile()
        {
            CreateMap<ArticleDomain, Article>()
                .IncludeBase<MaterialDomain, Material>();

            CreateMap<Article, ArticleDomain>()
                .IncludeBase<Material, MaterialDomain>();
        }
    }
}

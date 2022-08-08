namespace Portal.Application.MappingProfiles
{
    internal class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleDTO>()
                .IncludeBase<Material, MaterialDTO>();

            CreateMap<ArticleDTO, Article>()
                .IncludeBase<MaterialDTO, Material>();
        }
    }
}

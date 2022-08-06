namespace Portal.Application.MappingProfiles
{
    internal class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleDTO>();

            CreateMap<ArticleDTO, Article>();
        }
    }
}

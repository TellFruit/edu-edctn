namespace Portal.UI_MVC_Web.MappingProfiles
{
    public class ArticleListingProfile : Profile
    {
        public ArticleListingProfile()
        {
            CreateMap<ArticleDTO, ArticleListModel>();

            CreateMap<ArticleListModel, ArticleDTO>();
        }
    }
}

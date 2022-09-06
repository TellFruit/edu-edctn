namespace Portal.UI_MVC_Web.MappingProfiles
{
    public class ArticleListProfile : Profile
    {
        public ArticleListProfile()
        {
            CreateMap<ArticleDTO, ArticleListModel>();

            CreateMap<ArticleListModel, ArticleDTO>();
        }
    }
}

namespace Portal.UI_MVC_Web.MappingProfiles
{
    public class CourseArticleModelProfile : Profile
    {
        public CourseArticleModelProfile()
        {
            CreateMap<CourseArticleModel, ArticleDTO>();

            CreateMap<ArticleDTO, CourseArticleModel>();
        }
    }
}

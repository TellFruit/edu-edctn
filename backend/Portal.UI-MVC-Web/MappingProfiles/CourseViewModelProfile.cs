namespace Portal.UI_MVC_Web.MappingProfiles
{
    public class CourseViewModelProfile : Profile
    {
        public CourseViewModelProfile()
        {
            CreateMap<CourseViewModel, CourseDTO>();

            CreateMap<CourseDTO, CourseViewModel>()
                .ForMember(vm => vm.Articles, 
                    src => src.MapFrom(
                        dto => dto.Materials.OfType<ArticleDTO>()
                            .Select(a => new CourseArticleModel()
                            {
                                Id = a.Id,
                                Title = a.Title,
                                Published = a.Published,
                                Url = a.Url,
                                IsSelected = true
                            })
                            .ToList()));
        }
    }
}

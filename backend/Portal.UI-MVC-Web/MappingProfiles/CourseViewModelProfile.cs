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
                                Url = a.Url
                            })
                            .ToList()))
                .ForMember(vm => vm.Books,
                    src => src.MapFrom(
                        dto => dto.Materials.OfType<BookDTO>()
                            .Select(b => new CourseBookModel()
                            {
                                Id = b.Id,
                                Title = b.Title,
                                Format = b.Format,
                                Authors = b.Authors,
                                PageCount = b.PageCount,
                                Published = b.Published
                            })
                            .ToList()))
                .ForMember(vm => vm.Videos,
                    src => src.MapFrom(
                        dto => dto.Materials.OfType<VideoDTO>()
                            .Select(v => new CourseVideoModel()
                            {
                                Id = v.Id,
                                Title = v.Title,
                                Quality = v.Quality,
                                Duration = v.Duration
                            })
                            .ToList()));
        }
    }
}

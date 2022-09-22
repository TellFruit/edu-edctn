namespace Portal.UI_MVC_Web.MappingProfiles
{
    public class CourseBookModelProfile : Profile
    {
        public CourseBookModelProfile()
        {
            CreateMap<CourseBookModel, BookDTO>();

            CreateMap<BookDTO, CourseBookModel>();
        }
    }
}

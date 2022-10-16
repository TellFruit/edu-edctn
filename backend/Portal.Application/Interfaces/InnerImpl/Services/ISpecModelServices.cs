namespace Portal.Application.Interfaces.InnerImpl.Services
{
    public interface IArticleService : IModelService<ArticleDTO, ArticleDomain> { }
    public interface IBookService : IModelService<BookDTO, BookDomain> { }
    public interface IVideoService : IModelService<VideoDTO, VideoDomain> { }
    public interface IPerkService : IModelService<PerkDTO, PerkDomain> { }
    public interface IUserService : IModelService<UserDTO, UserDomain> { }
    public interface ICourseService : IModelService<CourseDTO, CourseDomain> { }
}

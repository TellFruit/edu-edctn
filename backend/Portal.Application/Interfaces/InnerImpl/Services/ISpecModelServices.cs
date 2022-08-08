namespace Portal.Application.Interfaces.InnerImpl.Services
{
    public interface IArticleService : IModelService<ArticleDTO> { }
    public interface IBookService : IModelService<BookDTO> { }
    public interface IVideoService : IModelService<VideoDTO> { }
    public interface IPerkService : IModelService<PerkDTO> { }
    public interface IUserService : IModelService<UserDTO> { }
    public interface ICourseService : IModelService<CourseDTO> { }
}

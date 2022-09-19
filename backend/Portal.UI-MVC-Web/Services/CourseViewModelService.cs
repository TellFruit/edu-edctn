using Portal.Application.Interfaces.Other;
using Portal.UI_MVC_Web.Interfaces;
using Portal.UI_MVC_Web.Models.Course;

namespace Portal.UI_MVC_Web.Services
{
    public class CourseViewModelService : IModifyCourseViewModel
    {
        private readonly ICourseService _courseService;
        private readonly IArticleService _articleService;
        private readonly ISerialize _serialize;

        private HttpContext _httpContext;
        private ModifyCourseModel _courseViewModel;

        public CourseViewModelService(ICourseService courseService, IArticleService articleService, ISerialize serialize)
        {
            _courseService = courseService;
            _articleService = articleService;
            _serialize = serialize;
        }

        public void SetHttpContext(HttpContext context)
        {
            _httpContext = context;
        }

        public void SetModelFromDTO(CourseDTO courseDTO)
        {
            _courseViewModel.Course = courseDTO;
        }

        public ModifyCourseModel GetModel()
        {
            if (_courseViewModel == null)
            {
                return ExtractModelFromSession();
            }

            return _courseViewModel;
        }

        public void AddArticle(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveArticle(int id)
        {
            throw new NotImplementedException();
        }

        private ModifyCourseModel ExtractModelFromSession()
        {
            var json = _httpContext.Session.GetString(nameof(ModifyCourseModel));

            if (json == null)
            {
                return new ModifyCourseModel();
            }

            return _serialize.Deserialize<ModifyCourseModel>(json);
        }

        private async Task<ChooseArticleModel> InitChooseArticleModel(ICollection<ArticleDTO> marked = null)
        {
            if (_courseViewModel.ChooseArticleModel != null)
            {
                return _courseViewModel.ChooseArticleModel;
            }

            _courseViewModel.ChooseArticleModel = new ChooseArticleModel();

            if (marked == null)
            {
                _courseViewModel.ChooseArticleModel.UnmarkedArticles = await _articleService.GetAll();
            }

            return _courseViewModel.ChooseArticleModel;
        }
    }
}

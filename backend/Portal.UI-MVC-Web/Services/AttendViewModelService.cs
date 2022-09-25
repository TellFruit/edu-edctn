namespace Portal.UI_MVC_Web.Services
{
    public class AttendViewModelService : IAttendViewModelService
    {
        private readonly ICourseViewModelService _courseView;
        private readonly ICourseService _courseDTO;
        private readonly IRuleUser _ruleUser;

        private UserDTO _loggedUser;

        public AttendViewModelService(ICourseViewModelService courseView, ICourseService courseDTO, IRuleUser ruleUser)
        {
            _courseView = courseView;
            _courseDTO = courseDTO;
            _ruleUser = ruleUser;
        }

        public IAttendViewModelService SetUser(UserDTO user)
        {
            _loggedUser = user;

            return this;
        }

        public async Task<CourseIndexModel> GetAttendedCourses()
        {
            var model = await _courseView.GetCourseIndexModel();

            var ids = _loggedUser.CourseProgress.Select(c => c.CourseId).ToList();

            model.Courses = model.Courses.Where(c => ids.Contains(c.Id)).ToList();

            model.LoggedUser = _loggedUser;

            return model;
        }

        public async Task<AttendViewModel> GetAttendModelById(int courseId)
        {
            var course = await _courseDTO.GetById(courseId);

            var learnedIds = _loggedUser.MaterialLearned.Select(m => m.MaterialId);

            var materialViews = course.Materials
                .Select(m => new AttendMaterialModel
                {
                    Material = m
                }).ToList();

            materialViews.Where(m => learnedIds.Contains(m.Material.Id)).ToList()
                .ForEach(m => m.IsLearned = true);

            return new AttendViewModel()
            {
                Course = course,
                User = _loggedUser,
                Materials = materialViews
            };
        }
    }
}

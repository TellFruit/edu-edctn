using Portal.Domain.Entities.Course;
using Portal.Domain.Entities.Course.Specification;
using Portal.Domain.Entities.User;
using Portal.Domain.Entities.User.Specification;

namespace Portal.Application.Services.Rules
{
    internal class RuleUserService : IRuleUser
    {
        private readonly IGenericRepository<UserDomain> _userRepos;
        private readonly IGenericRepository<CourseDomain> _courseRepos;
        private readonly IMapper _mapper;

        public RuleUserService(IGenericRepository<UserDomain> userRepos, IGenericRepository<CourseDomain> courseRepos, IMapper mapper)
        {
            _userRepos = userRepos;
            _courseRepos = courseRepos;
            _mapper = mapper;
        }

        public async Task<UserDTO> Enroll(int userId, int courseId)
        {
            var user = await GetUserById(userId);
            
            var course = await GetCourseById(courseId);
            if (user.CourseEnroll(course) is false)
            {
                throw new RelationAlreadyExistsException(nameof(user.CourseProgress));
            }

            await CallUserReposUpdate(user);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> Unenroll(int userId, int courseId)
        {
            var user = await GetUserById(userId);

            if (user.CourseUnenroll(courseId) is false)
            {
                throw new RelationNotFoundException(nameof(user.CourseProgress));
            }

            await CallUserReposUpdate(user);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> MarkLearned(int userId, int materialId)
        {
            var user = await GetUserById(userId);

            if (user.MarkMaterialLearned(materialId) is false)
            {
                throw new RelationAlreadyExistsException(nameof(user.MaterialLearned));
            }

            await CallUserReposUpdate(user);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> UnmarkLearned(int userId, int materialId)
        {
            var user = await GetUserById(userId);

            if (user.UnmarkMaterialLearned(materialId) is false)
            {
                throw new RelationNotFoundException(nameof(user.MaterialLearned));
            }

            await CallUserReposUpdate(user);

            return _mapper.Map<UserDTO>(user);
        }

        private async Task<UserDomain> GetUserById(int userId)
        {
            var spec = new UserByIdSpec(userId);

            var res = await _userRepos.Read(spec);
             
            return res.Last();
        }

        private async Task<CourseDomain> GetCourseById(int courseId)
        {
            var spec = new CourseByIdFilter(courseId);

            var res = await _courseRepos.Read(spec);

            return res.Last();
        }

        private async Task CallUserReposUpdate(UserDomain user)
        {
            await _userRepos.Update(user);
            _userRepos.SaveChanges();
        }
    }
}

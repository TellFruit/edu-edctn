namespace Portal.Application.Services.Rules
{
    internal class RuleUserService : IRuleUser
    {
        private readonly IGenericRepository<UserDomain> _userRepos;
        private readonly IGenericRepository<CourseDomain> _courseRepos;

        public RuleUserService(IGenericRepository<UserDomain> userRepos, IGenericRepository<CourseDomain> courseRepos)
        {
            _userRepos = userRepos;
            _courseRepos = courseRepos;
        }

        public async Task<bool> Enroll(int userId, int courseId)
        {
            var user = await GetUserById(userId);
            
            var course = await GetCourseById(courseId);
            if (user.CourseEnroll(course) is false)
            {
                throw new RelationAlreadyExistsException(nameof(user.CourseProgress));
            }

            await _userRepos.Update(user);

            return true;
        }

        public async Task<bool> Unenroll(int userId, int courseId)
        {
            var user = await GetUserById(userId);

            if (user.CourseUnenroll(courseId) is false)
            {
                throw new RelationNotFoundException(nameof(user.CourseProgress));
            }

            await _userRepos.Update(user);

            return true;
        }

        private async Task<UserDomain> GetUserById(int userId)
        {
            var res = await _userRepos.Read(x => x.Id.Equals(userId));

            return res.Last();
        }

        private async Task<CourseDomain> GetCourseById(int courseId)
        {
            var res = await _courseRepos.Read(c => c.Id.Equals(courseId));

            return res.Last();
        }
    }
}

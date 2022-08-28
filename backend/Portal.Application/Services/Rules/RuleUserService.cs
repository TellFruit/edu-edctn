namespace Portal.Application.Services.Rules
{
    internal class RuleUserService : IRuleUser
    {
        private readonly IGenericRepository<UserDomain> _userRepos;

        public RuleUserService(IGenericRepository<UserDomain> userRepos)
        {
            _userRepos = userRepos;
        }

        public async Task<bool> Enroll(int userId, int courseId)
        {
            var user = await GetUserById(userId);

            user.CourseEnroll(courseId);

            await _userRepos.Update(user);

            return true;
        }

        public async Task<bool> Unroll(int userId, int courseId)
        {
            var user = await GetUserById(userId);

            user.CourseUnroll(courseId);

            await _userRepos.Update(user);

            return true;
        }

        private async Task<UserDomain> GetUserById(int userId)
        {
            var res = await _userRepos.Read(x => x.Id.Equals(userId));

            return res.Last();
        }
    }
}

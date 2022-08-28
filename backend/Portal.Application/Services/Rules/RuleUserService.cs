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
            var res = await _userRepos.Read(x => x.Id.Equals(userId));
            var user = res.Last();

            user.CourseEnroll(courseId);

            await _userRepos.Update(user);

            return true;
        }

        public Task<bool> Unroll(int userId, int courseId)
        {
            throw new NotImplementedException();
        }
    }
}

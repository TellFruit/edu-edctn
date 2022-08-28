namespace Portal.Application.Services.Rules
{
    internal class RuleUserService : IRuleUser
    {
        private readonly IGenericRepository<UserDomain> _userRepos;

        public RuleUserService(IGenericRepository<UserDomain> userRepos)
        {
            _userRepos = userRepos;
        }

        public Task<bool> Enroll(int courseId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Unroll(int courseId)
        {
            throw new NotImplementedException();
        }
    }
}

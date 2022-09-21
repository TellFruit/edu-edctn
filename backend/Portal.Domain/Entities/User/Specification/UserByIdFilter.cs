namespace Portal.Domain.Entities.User.Specification
{
    public class UserByIdFilter : Specification<UserDomain>
    {
        private readonly int _userId;

        public UserByIdFilter(int articleId)
        {
            _userId = articleId;
        }

        public override bool IsSatisfiedBy(UserDomain item)
        {
            return item.Id.Equals(_userId);
        }
    }
}

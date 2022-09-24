namespace Portal.Domain.Entities.User.Specification
{
    public class UserByIdSpec : Specification<UserDomain>
    {
        private readonly int _userId;

        public UserByIdSpec(int userId)
        {
            _userId = userId;
        }

        public override bool IsSatisfiedBy(UserDomain item)
        {
            return item.Id.Equals(_userId);
        }
    }
}

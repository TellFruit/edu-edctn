namespace Portal.Domain.Entities.User.Specification
{
    public class UserByEmailSpec : Specification<UserDomain>
    {
        private readonly string _email;

        public UserByEmailSpec(string email)
        {
            _email = email;
        }

        public override bool IsSatisfiedBy(UserDomain item)
        {
            return item.Id.Equals(_email);
        }
    }
}

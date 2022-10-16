namespace Portal.Application.Validation
{
    public class UserValidator : AbstractValidator<UserDTO>
    {
        private readonly string _match = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";

        public UserValidator()
        {
            RuleFor(u => u.Email)
                .Matches(_match);

            RuleFor(u => u.Password)
                .NotEmpty();
        }
    }
}

namespace Portal.Application.Validation
{
    public class PerkValidator : AbstractValidator<PerkDTO>
    {
        public PerkValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty();
        }
    }
}

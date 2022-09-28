namespace Portal.Application.Validation
{
    public class CourseValidator : AbstractValidator<CourseDTO>
    {
        public CourseValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty();

            RuleFor(c => c.Description)
                .NotEmpty();

            RuleFor(c => c.Materials)
                .Must(m => m.Count > 0);

            RuleFor(c => c.Perks)
                .Must(p => p.Count > 0);
        }
    }
}

namespace Portal.Application.Validation
{
    public class VideoValidator : AbstractValidator<VideoDTO>
    {
        public VideoValidator()
        {
            RuleFor(v => v.Title)
                .NotEmpty();

            RuleFor(v => v.Quality)
                .GreaterThan(0);

            RuleFor(v => v.Duration)
                .GreaterThan(TimeSpan.Zero);
        }
    }
}

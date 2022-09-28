namespace Portal.Application.Validation
{
    public class ArticleValidator : AbstractValidator<ArticleDTO>
    {
        public readonly DateTime MinDate = new DateTime(1990, 12, 20);
        public readonly string Match = @"((?:http|ftp|https):\/\/(?:[\w_-]+(?:(?:\.[\w_-]+)+))(?:[\w.,@?^=%:\/~+#-]*[\w@?^=%\/~+#-]))";

        public ArticleValidator()
        {
            RuleFor(a => a.Title)
                .NotEmpty();

            RuleFor(a => a.Url)
                .Matches(Match);

            RuleFor(a => a.Published)
                .GreaterThan(MinDate);
        }
    }
}

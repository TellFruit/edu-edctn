namespace Portal.Application.Validation
{
    public class ArticleValidator : AbstractValidator<ArticleDTO>
    {
        private readonly DateTime _minDate = new DateTime(1990, 12, 20);
        private readonly string _match = @"((?:http|ftp|https):\/\/(?:[\w_-]+(?:(?:\.[\w_-]+)+))(?:[\w.,@?^=%:\/~+#-]*[\w@?^=%\/~+#-]))";

        public ArticleValidator()
        {
            RuleFor(a => a.Title)
                .NotEmpty();

            RuleFor(a => a.Url)
                .NotNull()
                .NotEmpty()
                .Matches(_match);

            RuleFor(a => a.Published)
                .GreaterThan(_minDate);
        }
    }
}

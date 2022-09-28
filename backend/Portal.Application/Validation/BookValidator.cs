namespace Portal.Application.Validation
{
    public class BookValidator : AbstractValidator<BookDTO>
    {
        private static readonly IList<string> _formats = new List<string>() { ".pdf", ".mobi", ".epub", ".doc", ".docx", ".odt" };
        private readonly string _match = "";

        public BookValidator()
        {
            RuleFor(b => b.Title)
                .NotEmpty();

            RuleFor(b => b.Authors)
                .Must(b => b.Count > 0)
                .Must(b => b.First().Length > 0);

            RuleFor(b => b.PageCount)
                .GreaterThan(0);

            RuleFor(b => b.Format)
                .PropertyMustBePresentIn(_formats);
        }
    }
}

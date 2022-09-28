namespace Portal.Application.Validation
{
    public static class HelpValidationExtension
    {
        public static bool Validate<T>(this T entity, AbstractValidator<T> validator)
        {
            return validator.Validate(entity).IsValid;
        }
    }
}

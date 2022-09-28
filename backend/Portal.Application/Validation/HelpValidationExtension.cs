namespace Portal.Application.Validation
{
    public static class HelpValidationExtension
    {
        public static bool Validate<T>(this T entity, AbstractValidator<T> validator)
        {
            return validator.Validate(entity).IsValid;
        }
        public static IRuleBuilderOptions<TSource, TDerived> PropertyMustBePresentIn<TSource, TDerived>(this IRuleBuilder<TSource, TDerived> ruleBuilder, IList<TDerived> possibleMatches)
        {
            return ruleBuilder.Must(input => possibleMatches.Contains(input));
        }
    }
}

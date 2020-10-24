using Expressions;
using FluentValidation;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace BudgetManagement.Shared.FluentValidation
{
    public abstract class BaseValidator<T> : AbstractValidator<T> where T : class
    {
        private const string DefaultParameterName = "req";
        private readonly Regex _languageCodeRegex = new Regex(@"^\D{2}-\D{2}$", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private readonly Regex _emailRegex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");

        public static string RequiredMessage(string parameterName)
        {
            parameterName = parameterName ?? string.Empty;

            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            var firstCharacter = parameterName.Length > 0 ? parameterName.ToLower().ToCharArray().ElementAt(0) : default(char);
            var isVowel = vowels.Contains(firstCharacter);
            var output = $"A{(isVowel ? "n" : string.Empty)} '{parameterName}' parameter is required.";

            return output;
        }

        public static string InvalidNumericMessage(string parameterName, bool optional) => $"The '{parameterName}' parameter is invalid. Must be greater than {(optional ? "or equal to " : string.Empty)}0.";

        public static string InvalidStringMessage(string parameterName, int length) => $"The '{parameterName}' parameter is invalid. [Maximum Length: {length} characters]";

        public static string InvalidGuidMessage(string parameterName) => $"The '{parameterName}' parameter is invalid. [Strict Length: 36 characters] [Example: xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx]";

        public static string InvalidLanguageCodeMessage(string parameterName) => $"The '{parameterName}' parameter is invalid. [Strict Length: 5 characters] [Example: en-us]";

        public static string InvalidEmailMessage(string parameterName, int length) => $"The '{parameterName}' parameter is invalid. [Maximum Length: {length} characters] [Example: name@address.com]";

        protected IRuleBuilderOptions<T, int> GetRequiredIntRule(string propertyName, string parameterName)
        {
            var returnExpression = ExpressionExtensions.CreateReturnExpression<T, int>(propertyName, DefaultParameterName);
            var invalidMessage = InvalidNumericMessage(parameterName, false);

            return RuleFor(returnExpression)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage(invalidMessage);
        }

        protected IRuleBuilderOptions<T, long> GetRequiredLongRule(string propertyName, string parameterName)
        {
            var returnExpression = ExpressionExtensions.CreateReturnExpression<T, long>(propertyName, DefaultParameterName);
            var invalidMessage = InvalidNumericMessage(parameterName, false);

            return RuleFor(returnExpression)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage(invalidMessage);
        }

        protected IRuleBuilderOptions<T, decimal> GetRequiredMoneyRule(string propertyName, string parameterName)
        {
            var returnExpression = ExpressionExtensions.CreateReturnExpression<T, decimal>(propertyName, DefaultParameterName);
            var invalidMessage = InvalidNumericMessage(parameterName, false);

            return RuleFor(returnExpression)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage(invalidMessage)
                .ScalePrecision(2, 10, ignoreTrailingZeros: true);
        }

        protected IRuleBuilderOptions<T, string> GetRequiredStringRule(string propertyName, string parameterName)
        {
            var returnExpression = ExpressionExtensions.CreateReturnExpression<T, string>(propertyName, DefaultParameterName);
            var requiredMessage = RequiredMessage(parameterName);

            return RuleFor(returnExpression)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage(requiredMessage)
                .NotEmpty().WithMessage(requiredMessage);
        }

        protected IRuleBuilderOptions<T, string> GetRequiredGuidRule(string propertyName, string parameterName)
        {
            var returnExpression = ExpressionExtensions.CreateReturnExpression<T, string>(propertyName, DefaultParameterName);
            var requiredMessage = RequiredMessage(parameterName);
            var invalidMessage = InvalidGuidMessage(parameterName);

            return RuleFor(returnExpression)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage(requiredMessage)
                .NotEmpty().WithMessage(requiredMessage)
                .Length(36).WithMessage(invalidMessage);
        }

        protected IRuleBuilderOptions<T, DateTime> GetRequiredDateRule(string propertyName, string parameterName)
        {
            var returnExpression = ExpressionExtensions.CreateReturnExpression<T, DateTime>(propertyName, DefaultParameterName);
            var invalidMessage = RequiredMessage(parameterName);

            return RuleFor(returnExpression)
                .Cascade(CascadeMode.Stop)
                .Must(x => x > DateTime.MinValue).WithMessage(invalidMessage);
        }

        protected IRuleBuilderOptions<T, int> GetInvalidIntRule(string propertyName, string parameterName)
        {
            var returnExpression = ExpressionExtensions.CreateReturnExpression<T, int>(propertyName, DefaultParameterName);
            var invalidMessage = InvalidNumericMessage(parameterName, true);

            return RuleFor(returnExpression)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage(invalidMessage);
        }

        protected IRuleBuilderOptions<T, int?> GetInvalidNullableIntRule(string propertyName, string parameterName)
        {
            var returnExpression = ExpressionExtensions.CreateReturnExpression<T, int?>(propertyName, DefaultParameterName);
            var invalidMessage = InvalidNumericMessage(parameterName, true);

            return RuleFor(returnExpression)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage(invalidMessage);
        }

        protected IRuleBuilderOptions<T, long> GetInvalidLongRule(string propertyName, string parameterName)
        {
            var returnExpression = ExpressionExtensions.CreateReturnExpression<T, long>(propertyName, DefaultParameterName);
            var invalidMessage = InvalidNumericMessage(parameterName, true);

            return RuleFor(returnExpression)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage(invalidMessage);
        }

        protected IRuleBuilderOptions<T, long?> GetInvalidNullableLongRule(string propertyName, string parameterName)
        {
            var returnExpression = ExpressionExtensions.CreateReturnExpression<T, long?>(propertyName, DefaultParameterName);
            var invalidMessage = InvalidNumericMessage(parameterName, true);

            return RuleFor(returnExpression)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage(invalidMessage);
        }

        protected IRuleBuilderOptions<T, decimal> GetInvalidMoneyRule(string propertyName, string parameterName)
        {
            var returnExpression = ExpressionExtensions.CreateReturnExpression<T, decimal>(propertyName, DefaultParameterName);
            var invalidMessage = InvalidNumericMessage(parameterName, true);

            return RuleFor(returnExpression)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage(invalidMessage)
                .ScalePrecision(2, 10, ignoreTrailingZeros: true);
        }

        protected IRuleBuilderOptions<T, decimal?> GetInvalidNullableMoneyRule(string propertyName, string parameterName)
        {
            var returnExpression = ExpressionExtensions.CreateReturnExpression<T, decimal?>(propertyName, DefaultParameterName);
            var invalidMessage = InvalidNumericMessage(parameterName, true);

            return RuleFor(returnExpression)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage(invalidMessage)
                .ScalePrecision(2, 10, ignoreTrailingZeros: true);
        }

        protected IRuleBuilderOptions<T, string> GetInvalidStringRule(string propertyName, string parameterName, int length)
        {
            var invalidMessage = InvalidStringMessage(parameterName, length);
            var returnExpression = ExpressionExtensions.CreateReturnExpression<T, string>(propertyName, DefaultParameterName);
            var notIsNullOrWhiteSpaceExpression = ExpressionExtensions.CreateIsNullOrWhiteSpaceExpression<T>(propertyName, false, DefaultParameterName);

            return RuleFor(returnExpression)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(length).WithMessage(invalidMessage)
                .When(notIsNullOrWhiteSpaceExpression.Compile());
        }

        protected IRuleBuilderOptions<T, string> GetInvalidLanguageCodeRule(string propertyName, string parameterName)
        {
            var returnExpression = ExpressionExtensions.CreateReturnExpression<T, string>(propertyName, DefaultParameterName);
            var notIsNullOrWhiteSpaceExpression = ExpressionExtensions.CreateIsNullOrWhiteSpaceExpression<T>(propertyName, false, DefaultParameterName);
            var invalidLanguageCodeMessage = InvalidLanguageCodeMessage(parameterName);

            return RuleFor(returnExpression)
                .Cascade(CascadeMode.Stop)
                .Must(languageCode => _languageCodeRegex.IsMatch(languageCode)).WithMessage(invalidLanguageCodeMessage)
                .When(notIsNullOrWhiteSpaceExpression.Compile());
        }

        protected IRuleBuilderOptions<T, string> GetInvalidEmailRule(string propertyName, string parameterName, int length)
        {
            var returnExpression = ExpressionExtensions.CreateReturnExpression<T, string>(propertyName, DefaultParameterName);
            var notIsNullOrWhiteSpaceExpression = ExpressionExtensions.CreateIsNullOrWhiteSpaceExpression<T>(propertyName, false, DefaultParameterName);
            var invalidMessage = InvalidStringMessage(parameterName, length);
            var invalidEmailMessage = InvalidEmailMessage(parameterName, length);

            return RuleFor(returnExpression)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(length).WithMessage(invalidMessage)
                .Must(languageCode => _emailRegex.IsMatch(languageCode)).WithMessage(invalidEmailMessage)
                .When(notIsNullOrWhiteSpaceExpression.Compile());
        }
    }
}
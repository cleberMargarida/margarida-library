using FluentValidation;

namespace Margarida.Util.Validation
{
    public static class ValidationExt
    {
        public static IRuleBuilderOptions<T, object> Required<T>
            (this IRuleBuilder<T, object> rule) => rule
                .NotEmpty()
                .WithMessage("The {PropertyName} field is required.");

        public static IRuleBuilderOptions<T, string> RequiredLength<T>
            (this IRuleBuilder<T, string> rule, int min, int max) => rule
                .Length(min, max)
                .WithMessage($"The {"{PropertyName}"} required more than {min} and less than. {max}");

        public static IRuleBuilderOptions<T, string> RequiredLowerCase<T>
            (this IRuleBuilder<T, string> rule) => rule
                .Must(x => x.Any(char.IsLower))
                .WithMessage($"The {"{PropertyName}"} require at least lower case.");

        public static IRuleBuilderOptions<T, string> RequiredUpperCase<T>
            (this IRuleBuilder<T, string> rule) => rule
                .Must(x => x.Any(char.IsUpper))
                .WithMessage($"The {"{PropertyName}"} require at least upper case.");
    }
}

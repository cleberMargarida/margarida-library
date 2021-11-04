using Newtonsoft.Json;
using FluentValidation;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace Margarida.Util
{
    public static class Utilities
    {
        public static string Serialize<T>(this T input)
            => JsonConvert.SerializeObject(input);

        public static T Deserialize<T>(this string input) where T : new()
            => JsonConvert.DeserializeObject<T>(input) ?? new T();

        public static TSource Inner<TSource>(this TSource input, Action<TSource> action)
        {
            if (action != null && input != null)
            {
                action(input);
            }

            return input;
        }
    }

    public static class Strings
    {
        public static string Between(this string str, string firstString, string lastString)
        {
            int pos1 = str.IndexOf(firstString) + firstString.Length;
            int pos2 = str.Substring(pos1).IndexOf(lastString);
            return str.Substring(pos1, pos2);
        }

        public static string Unescape(this string textString) => Regex.Unescape(textString);
    }

    public static class Validations
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

    public static class Convert
    {
        /// <summary>
        /// Convert a string number into int.
        /// Safe method, if the string is not convertible, the return will be 0.
        /// </summary>
        /// <param name="input">String number.</param>
        /// <returns>Number converted.</returns>
        public static int ToInt(this string input)
        {
            int.TryParse(input, out var convertedInt);

            return convertedInt;
        }

        /// <summary>
        /// Return a copy of an object into new instance.
        /// </summary>
        /// <typeparam name="T">Type of the object will be copied.</typeparam>
        /// <param name="object">The object will be copied. </param>
        /// <returns>Copy of an object into new instance.</returns>
        public static T Clone<T>(this T @object)
            where T : new() => @object.Serialize().Deserialize<T>();

        /// <summary>
        /// Return a copy of an object into another object with other type but same fields.
        /// </summary>
        /// <typeparam name="T">Type of destiny object.</typeparam>
        /// <param name="source">Source object will be copied.</param>
        /// <returns>Copy of an object into another.</returns>
        public static T Copy<T>(this object source) where T : new()
        {
            return TryConvert(source);

            T TryConvert(object source)
            {
                try
                {
                    return source.Serialize().Deserialize<T>();
                }
                catch (Exception ex)
                {
                    TryParse(source, out var copy, ex);
                    return copy;
                }
            }

            void TryParse(object source, out T outter, Exception ex)
            {
                var graph = JObject.Parse(source.Serialize());
                ExtractMembersFromException(ex, out var value, out var propertiesLevel);
                TreatedMembers(graph, propertiesLevel, level: 0, value);
                outter = TryConvert(graph);

                void TreatedMembers(JObject? graph, string[] propertiesLevel, int level, string value)
                {
                    if (graph?.Property(propertiesLevel[level])?.Value.ToString() == value)
                    {
                        graph.Property(propertiesLevel[level])?.Remove();
                    }
                    else
                    {
                        TreatedMembers(graph?[propertiesLevel[level]] as JObject, propertiesLevel, ++level, value);
                    }
                }

                (string, string[]) ExtractMembersFromException(Exception ex, out string value, out string[] propertiesLevel)
                {
                    return (value = ex.Message.Between(": ", ". Path"), propertiesLevel = ex.Message.Between(" Path '", "'").Split('.'));
                }
            }
        }
    }
}

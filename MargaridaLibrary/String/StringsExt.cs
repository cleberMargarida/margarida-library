using System.Text.RegularExpressions;

namespace Margarida.Util.String
{
    public static class StringsExt
    {
        public static string Between(this string str, string firstString, string lastString) =>
            str.Substring(str.IndexOf(firstString) + firstString.Length,
                str.Substring(str.IndexOf(firstString) + firstString.Length).IndexOf(lastString));

        public static string Unescape(this string textString) => Regex.Unescape(textString);
    }
}

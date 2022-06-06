using System.Text.RegularExpressions;

namespace Margarida.Util.String
{
    public static class StringsExt
    {
        public static string Between(this string str, string firstString, string lastString)
        {
            return str.Substring(str.IndexOf(firstString) + firstString.Length,
                                 str.Substring(str.IndexOf(firstString) + firstString.Length).IndexOf(lastString));
        }

        public static string Unescape(this string textString) => Regex.Unescape(textString);

        public static void Add(this char[] arr, char el)
        {
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] == '\0')
                {
                    arr[i] = el;
                    break;
                }
        }

        public static Dictionary<int,char> GetPositionCharPairs(this string source, int i = 0)
        {
            Dictionary<int, char> pairs = new();
            foreach (char c in source)
            {
                pairs.Add(i, c);
                i++;
            }
            return pairs;
        }

        public static string GetOnlyNumbers(this string source)
        {
            return new string(source.Where(char.IsNumber).ToArray());
        }
    }
}

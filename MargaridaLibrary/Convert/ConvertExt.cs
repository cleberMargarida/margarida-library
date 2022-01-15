using Margarida.Util.Enumerable;
using Margarida.Util.String;

namespace Margarida.Util.Convert
{
    public static class ConvertExt
    {
        private const char year = 'y', month = 'm', day = 'd', slash = '/';
        private const int SlashPositionToYear = 4, SlashPositionToMonth = 7;

        public static int ToInt(this string input)
        {
            int.TryParse(input, out var convertedInt);
            return convertedInt;
        }

        public static DateTime SetDateTimeFrom(this DateTime dateTime, string dateTimeString)
        {
            dateTime = DateTime.Parse(dateTimeString);
            return dateTime;
        }

        public static DateTime SetDateTimeFrom(this DateTime source, string dateTimeString, string dateFormat, int yearCount = 3, int monthCount = 6, int dayCount = 9)
        {
            char[] sourceArr = dateTimeString.ToCharArray(), temp = new char[dateTimeString.Length];

            for (int i = dateFormat.Length - 1; i >= 0; --i)
            {
                if (dateFormat[i] is year)
                    temp[yearCount--] = sourceArr[i];

                else if (dateFormat[i] is month)
                    temp[monthCount--] = sourceArr[i];

                else if (dateFormat[i] is day)
                    temp[dayCount--] = sourceArr[i];
            }

            temp = temp.InsertAt(slash, SlashPositionToYear)
                       .InsertAt(slash, SlashPositionToMonth);

            return source.SetDateTimeFrom(new string(temp));
        }
    }
}

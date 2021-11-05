namespace Margarida.Util.Convert
{
    public static class ConvertExt
    {
        public static int ToInt(this string input)
        {
            int.TryParse(input, out var convertedInt);
            return convertedInt;
        }
    }
}

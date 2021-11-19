namespace Margarida.Util.Number
{
    public static class NumberExt
    {
        public static int RandomNumber() => new Random().Next(0, int.MaxValue);

        public static int RandomNumber(this int max) => new Random().Next(0, max);
    }
}

namespace Margarida.Util.Number
{
    public static class NumberExt
    {
        private static Random random = new Random();

        public static int RandomNumber() => random.Next(0, int.MaxValue);

        public static int RandomNumber(this int max) => random.Next(max);
    }
}

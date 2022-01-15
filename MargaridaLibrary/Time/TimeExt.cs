namespace Margarida.Util.Time
{
    public static class TimeExt
    {
        public static int Bimester(this DateTime dateTime) => (dateTime.Month + 2) / 3;
    }
}

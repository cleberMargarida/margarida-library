namespace Margarida.Util.Bool
{
    public static class BoolExt
    {
        public static bool Not(this object o, Func<object, bool> func) => !func(o);
        public static bool Or(this bool o, bool or) => o || or;
        public static bool And(this bool a, bool an) => a && an;
    }
}

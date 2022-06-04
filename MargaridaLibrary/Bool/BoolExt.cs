namespace Margarida.Util.Bool
{
    public static class BoolExt
    {
        public static bool Not(this object o, Func<object, bool> func)
        {
            return !func(o);
        }

        public static bool Then(this bool left, bool right)
        {
            return !left || right;
        }

        public static WhenTrue<T> WhenItsTrue<T>(this T input, bool condition)
        {
            return new WhenTrue<T>(input, condition);
        }

        public static BoolProviderUnique Value(this bool boolean)
        {
            return new BoolProviderUnique(boolean);
        }

        public static BoolProvider With(this bool left, bool right)
        {
            return new BoolProvider(left, right);
        }

        public static BoolProvider With(this BoolProvider boolProvider, bool third)
        {
            return new BoolProvider(boolProvider, third);
        }
    }
}

namespace Margarida.Util.Bool
{
    public static class AwesomeBoolExt
    {
        public static bool Not(this object o, Func<object, bool> func)
        {
            return !func(o);
        }

        public static bool Then(this bool left, bool right)
        {
            return !left || right;
        }

        public static WhenTrue<T> When<T>(this T input, bool condition)
        {
            return new WhenTrue<T>(input, condition);
        }

        public static WhenTrue<T> When<T>(this T input, Func<T, bool> condition)
        {
            return new WhenTrue<T>(input, condition);
        }

        public static AwesomeBoolSingle Value(this bool boolean)
        {
            return new AwesomeBoolSingle(boolean);
        }

        public static AwesomeBool With(this bool left, bool right)
        {
            return new AwesomeBool(left, right);
        }

        public static AwesomeBool With(this AwesomeBool boolProvider, bool third)
        {
            return new AwesomeBool(boolProvider, third);
        }
    }
}

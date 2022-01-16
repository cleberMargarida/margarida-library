namespace Margarida.Util.Bool
{
    public static class BoolExt
    {
        public static bool Not(this object o, Func<object, bool> func) => !func(o);
        
        public static bool Then(this bool left, bool right) => !left || right;

        public static BoolProviderUnique Value(this bool boolean) => new BoolProviderUnique(boolean);

        public static BoolProvider With(this bool left, bool right) => new BoolProvider(left, right);

        public static BoolProvider With(this BoolProvider boolProvider, bool third) => new BoolProvider(boolProvider, third);
    }
}

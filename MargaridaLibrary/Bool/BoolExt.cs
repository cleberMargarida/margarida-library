namespace Margarida.Util.Bool
{
    public static class BoolExt
    {
        public static bool Not(this object o, Func<object, bool> func) => !func(o);
        
        public static bool Then(this bool left, bool right) => !left || right;

        public static BoolProviderUnique Value(this bool boolean) => new BoolProviderUnique(boolean);

        public static BoolProviderDuo With(this bool left, bool right) => new BoolProviderDuo(left, right) ;

    }

    public class BoolProviderUnique
    {
        private bool nextBool;
        
        public BoolProviderUnique(bool boolean)
        {
            nextBool = boolean;
        }

        public bool IsTrue => nextBool == true;

        public bool IsFalse => nextBool == false;

        public bool Not => !nextBool;

        public bool Value => nextBool;
    }

    public class BoolProviderDuo
    {
        private bool left;
        private bool right;

        public BoolProviderDuo(bool left, bool right)
        {
            this.left = left;
            this.right = right;
        }

        public bool ResultInTrue => left && right;

        public bool ResultInFalse => !left && !right;

        public bool ResultOfImplication => !left || right;

        public bool HasSameValue => left == right;
    }
}

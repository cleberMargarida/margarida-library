namespace Margarida.Util.Bool
{
    public class BoolProviderUnique
    {
        private bool nextBool;

        public BoolProviderUnique(bool boolean)
        {
            nextBool = boolean;
        }

        public static implicit operator bool (BoolProviderUnique provider)
        {
            return provider.nextBool;
        }

        public bool IsTrue => nextBool == true;

        public bool IsFalse => nextBool == false;

        public bool Not => !nextBool;

    }
}

namespace Margarida.Util.Bool
{
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
}

namespace Margarida.Util.Bool
{
    public class AwesomeBoolSingle
    {
        private bool nextBool;

        public AwesomeBoolSingle(bool boolean)
        {
            nextBool = boolean;
        }

        public static implicit operator bool (AwesomeBoolSingle provider)
        {
            return provider.nextBool;
        }

        public bool IsTrue => nextBool == true;

        public bool IsFalse => nextBool == false;

        public bool Not => !nextBool;

    }
}

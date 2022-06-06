namespace Margarida.Util.Bool
{
    public class AwesomeBool
    {
        protected bool left;
        protected bool right;
        private AwesomeBool? local;

        public AwesomeBool(bool left, bool right)
        {
            this.left = left;
            this.right = right;
        }

        public AwesomeBool(AwesomeBool local, bool right)
        {
            this.local = local;
            this.right = right;
        }

        public bool ResultInTrue
        {
            get
            {
                if (local is null) return left && right;
                return local.ResultInTrue && right;
            }
        }

        public bool ResultInFalse
        {
            get
            {
                if (local is null) return !left && !right;
                return local.ResultInFalse && !right;
            }
        }

        public bool ResultOfImplication
        {
            get
            {
                if (local is null) return !left || right;
                return local.ResultOfImplication || right;
            }
        }

        public bool HasSameValue
        {
            get
            {
                if (local is null) return left == right;
                return local.ResultInTrue && right;
            }
        }
    }
}

namespace Margarida.Util.Bool
{
    public class BoolProvider
    {
        protected bool left;
        protected bool right;
        private BoolProvider? local;

        public BoolProvider(bool left, bool right)
        {
            this.left = left;
            this.right = right;
        }

        public BoolProvider(BoolProvider local, bool right)
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

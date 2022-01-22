namespace Margarida.Util.Func
{
    public class Act<TIn, TOut>
    {
        private Func<TIn, TOut> function;
        private TIn entry;
        private TOut result;

        public TOut Result => result;

        public Act(TIn entry)
        {
            this.entry = entry;
        }

        public Act(Func<TIn, TOut> function)
        {
            this.function = function;
        }

        public Act(Func<TIn, TOut> function, TIn entry)
        {
            this.entry = entry;
            this.function = function;
        }

        public Act(Func<TIn, TOut> function, TOut? result)
        {
            this.function = function;
            this.result = result;
        }

        public Act<TIn, TOut> Where(Func<TIn, bool> predicate)
        {
            if (predicate.Invoke(entry))
                result = function.Invoke(entry);

            return this;
        }

        public Act<TIn, TOut> With(TIn entry)
        {
            this.entry = entry;
            return this;
        }
    }
}
namespace Margarida.Util.Expressions
{
    public class ForEachParty<T>
    {
        private IEnumerable<T> sequence;

        public ForEachParty(IEnumerable<T> sequence) => this.sequence = sequence;

        public List<TOut> Add<TOut>(Func<T, TOut> predicate)
        {
            var results = new List<TOut>();
            foreach (var item in sequence)
                results.Add(predicate(item));
            return results;
        }

        public List<TOut> AddRange<TOut>(Func<T, IEnumerable<TOut>> predicate)
        {
            var results = new List<TOut>();
            foreach (var item in sequence)
                results.AddRange(predicate(item));
            return results;
        }
    }
}

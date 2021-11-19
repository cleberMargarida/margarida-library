using Margarida.Util.Type;
using Margarida.Util.Bool;
using Margarida.Util.Number;

namespace Margarida.Util.List
{
    public static class ListExt
    {
        public static IEnumerable<IEnumerable<T>> ChunkBy<T>(this IEnumerable<T> source, int chunkSize) => source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();

        public static void AddRange<T>(this IList<T> dest, IEnumerable<T> source)
        {
            foreach (var set in source)
                dest?.Add(set);
        }

        public static T? RandomElement<T>(this IEnumerable<T> list) where T : new()
            => list.HasValue() ? list.ElementAt(list.Count() - 1.RandomNumber()) : default(T);
    }
}

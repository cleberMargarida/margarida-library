using Margarida.Util.Number;
using Margarida.Util.Type;

namespace Margarida.Util.Enumerable
{
    public static class EnumerableExt
    {
        public static IEnumerable<IEnumerable<T>> ChunkBy<T>(this IEnumerable<T> source, int chunkSize)
        {
            return source.Select((x, i) => new { Index = i, Value = x })
                         .GroupBy(x => x.Index / chunkSize)
                         .Select(x => x.Select(v => v.Value).ToList())
                         .ToList();
        }

        public static void AddRange<T>(this IList<T> dest, IEnumerable<T> source)
        {
            foreach (var set in source)
                dest?.Add(set);
        }

        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> func)
        {
            var keyVisited = new HashSet<TKey>();

            foreach (T elemento in source)
                if (keyVisited.Add(func(elemento)))
                    yield return elemento;
        }

        public static T[] InsertAt<T> (this T[] arr, T element, int index)
        {
            var temp = new T[arr.Count() + 1];

            for (int i = 0; i < arr.Count(); i++)
            {
                if (i == index) continue;
                temp[i] = arr[i];
            }

            temp[index] = element;
            arr = temp;
            return arr;
        }

        public static T? GetRandom<T>(this IEnumerable<T> ts) where T : new()
        {
            return ts.HasValue() ? ts.ElementAt((ts.Count() - 1).RandomNumber()) : default(T);
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = (n +1).RandomNumber();
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static void AddIfNotExist<TKey, TValue>(this Dictionary<TKey,TValue> dict, TKey key, TValue value) where TKey : new() where TValue : new()
        {
            if (dict.ContainsKey(key))
                return;

            dict.Add(key, value);
        }
    }
}

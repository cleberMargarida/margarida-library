using Margarida.Util.Helpers;
using System.Linq.Expressions;

namespace Margarida.Util.Linq
{
    public static class LinqExt
    {
        public static T? Most<T>(this IEnumerable<T> enumerable, Func<T, T, bool> predicate)
        {
            T? actual = enumerable.FirstOrDefault();
            if (actual is null) return actual;

            foreach (var item in enumerable)
                if (predicate(item, actual))
                    actual = item;

            return actual;
        }

        public static TSource Inner<TSource>(this TSource input, Action<TSource> action)
        {
            action(input);
            return input;
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source) action(item);
        }

        public static ForEachParty<T> ForEach<T>(this IEnumerable<T> sequence)
        {
            return new ForEachParty<T>(sequence);
        }

        public static void Repeat(this int times, Action action)
        {
            for (var i = 0; i < times; i++) action();
        }
    }
}

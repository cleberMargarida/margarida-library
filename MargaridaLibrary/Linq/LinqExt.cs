using System.Linq.Expressions;

namespace Margarida.Util.Linq
{
    public static class LinqExt
    {
        public static TSource Inner<TSource>(this TSource input, Action<TSource> action)
        {
            action(input);
            return input;
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
                action(item);
        }

        public static void Repeat(this int times, Action action)
        {
            for (var i = 0; i < times; i++)
                action();
        }
    }
}

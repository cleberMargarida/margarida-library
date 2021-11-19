using Margarida.Util.Bool;
using Margarida.Util.String;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace Margarida.Util.Linq
{
    public static class LinqExt
    {
        public static TSource Inner<TSource>(this TSource input, Action<TSource> action)
        {
            action(input);
            return input;
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> act)
        {
            foreach (var item in source)
                act(item);
        }
    }
}

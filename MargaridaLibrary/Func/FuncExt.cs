namespace Margarida.Util.Func
{
    public static class FuncExt
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

        public static void Repeat<T>(this int times, Action action)
        {
            for (var i = 0; i < times; i++)
                action();

        }

        public static Act<TIn, TOut> DoIt<TIn, TOut>(this Func<TIn, TOut> function) => new Act<TIn, TOut>(function);

        public static Act<TIn, TOut> DoIt<TIn, TOut>(this Act<TIn, TOut> function, TIn param) => new Act<TIn, TOut>(function, param);
    }
}

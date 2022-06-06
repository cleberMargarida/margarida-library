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

        public static void Repeat<T>(this int times, Action action)
        {
            for (var i = 0; i < times; i++)
                action();
        }

        public static AwesomeAction<TIn> With<TIn>(this Action<TIn> action,
                                                   TIn in1)
        {
            return new AwesomeAction<TIn>(action, in1);
        }

        public static AwesomeAction<TIn1, TIn2> With<TIn1, TIn2>(this Action<TIn1, TIn2> action,
                                                                 TIn1 in1,
                                                                 TIn2 in2)
        {
            return new AwesomeAction<TIn1, TIn2>(action, in1, in2);
        }

        public static AwesomeAction<TIn1, TIn2, TIn3> With<TIn1, TIn2, TIn3>(this Action<TIn1, TIn2, TIn3> action,
                                                                             TIn1 in1,
                                                                             TIn2 in2,
                                                                             TIn3 in3)
        {
            return new AwesomeAction<TIn1, TIn2, TIn3>(action, in1, in2, in3);
        }

        public static AwesomeAction<TIn1, TIn2, TIn3, TIn4> With<TIn1, TIn2, TIn3, TIn4>(this Action<TIn1, TIn2, TIn3, TIn4> action,
                                                                                         TIn1 in1,
                                                                                         TIn2 in2,
                                                                                         TIn3 in3,
                                                                                         TIn4 in4)
        {
            return new AwesomeAction<TIn1, TIn2, TIn3, TIn4>(action, in1, in2, in3, in4);
        }

        public static AwesomeAction<TIn1, TIn2, TIn3, TIn4, TIn5> With<TIn1, TIn2, TIn3, TIn4, TIn5>(this Action<TIn1, TIn2, TIn3, TIn4, TIn5> action,
                                                                                                     TIn1 in1,
                                                                                                     TIn2 in2,
                                                                                                     TIn3 in3,
                                                                                                     TIn4 in4,
                                                                                                     TIn5 in5)
        {
            return new AwesomeAction<TIn1, TIn2, TIn3, TIn4, TIn5>(action, in1, in2, in3, in4, in5);
        }

        public static AwesomeFunc<TIn, TOut> With<TIn, TOut>(this Func<TIn, TOut> function,
                                                             TIn in1)
        {
            return new AwesomeFunc<TIn, TOut>(function, in1);
        }

        public static AwesomeFunc<TIn1, TIn2, TOut> With<TIn1, TIn2, TOut>(this Func<TIn1, TIn2, TOut> function,
                                                                           TIn1 in1,
                                                                           TIn2 in2)
        {
            return new AwesomeFunc<TIn1, TIn2, TOut>(function, in1, in2);
        }

        public static AwesomeFunc<TIn1, TIn2, TIn3, TOut> With<TIn1, TIn2, TIn3, TOut>(this Func<TIn1, TIn2, TIn3, TOut> function,
                                                                                       TIn1 in1,
                                                                                       TIn2 in2,
                                                                                       TIn3 in3)
        {
            return new AwesomeFunc<TIn1, TIn2, TIn3, TOut>(function, in1, in2, in3);
        }

        public static AwesomeFunc<TIn1, TIn2, TIn3, TIn4, TOut> With<TIn1, TIn2, TIn3, TIn4, TOut>(this Func<TIn1, TIn2, TIn3, TIn4, TOut> function,
                                                                                                   TIn1 in1,
                                                                                                   TIn2 in2,
                                                                                                   TIn3 in3,
                                                                                                   TIn4 in4)
        {
            return new AwesomeFunc<TIn1, TIn2, TIn3, TIn4, TOut>(function, in1, in2, in3, in4);
        }

        public static AwesomeFunc<TIn1, TIn2, TIn3, TIn4, TIn5, TOut> With<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>(this Func<TIn1, TIn2, TIn3, TIn4, TIn5, TOut> function,
                                                                                                               TIn1 in1,
                                                                                                               TIn2 in2,
                                                                                                               TIn3 in3,
                                                                                                               TIn4 in4,
                                                                                                               TIn5 in5)
        {
            return new AwesomeFunc<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>(function, in1, in2, in3, in4, in5);
        }
    }
}

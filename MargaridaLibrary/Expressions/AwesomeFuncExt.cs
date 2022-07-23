namespace Margarida.Util.Expressions
{
    public static class AwesomeFuncExt
    {

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
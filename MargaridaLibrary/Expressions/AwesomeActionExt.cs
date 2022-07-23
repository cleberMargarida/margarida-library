namespace Margarida.Util.Expressions
{
    public static class AwesomeActionExt
    {
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
    }
}

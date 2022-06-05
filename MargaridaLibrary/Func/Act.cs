using Margarida.Util.Bool;

namespace Margarida.Util.Func
{
    public abstract class Act<TOut>
    {
        protected bool condition = true;
        protected TOut result;

        private TOut Result => ApplyFunctionAndGet().WhenItsTrue(condition);
        
        protected abstract TOut ApplyFunctionAndGet();
        
        public static implicit operator TOut(Act<TOut> act)
        {
            return act.Result;
        }
    }

    public class Act<TIn, TOut> : Act<TOut>
    {
        private TIn in1;
        
        public Func<TIn, TOut> Function { get; set; }

        public Act(TIn in1)
        {
            this.in1 = in1;
        }

        public Act(Func<TIn, TOut> function)
        {
            this.Function = function;
        }

        public Act(Func<TIn, TOut> function, TIn in1)
        {
            this.in1 = in1;
            this.Function = function;
        }

        public Act(Func<TIn, TOut> function, TOut? result)
        {
            this.Function = function;
            this.result = result;
        }

        public Act<TIn, TOut> When(Func<TIn, bool> predicate)
        {
            condition = condition && predicate.Invoke(in1);
            return this;
        }

        protected override TOut ApplyFunctionAndGet()
        {
            return (result = Function.Invoke(in1));
        }

        public Act<TIn, TOut> With(TIn in1)
        {
            this.in1 = in1;
            return this;
        }
    }

    public class Act<TIn1, TIn2, TOut> : Act<TOut>
    {
        private TIn1 in1;
        private TIn2 in2;
        
        public Func<TIn1, TIn2, TOut> Function { get; set; }

        public Act(TIn1 in1, TIn2 in2)
        {
            this.in1 = in1;
            this.in2 = in2;
        }

        public Act(Func<TIn1, TIn2, TOut> function)
        {
            this.Function = function;
        }

        public Act(Func<TIn1, TIn2, TOut> function, TIn1 in1, TIn2 in2)
        {
            this.in1 = in1;
            this.in2 = in2;
            this.Function = function;
        }

        public Act(Func<TIn1, TIn2, TOut> function, TOut? result)
        {
            this.Function = function;
            this.result = result;
        }

        public Act<TIn1, TIn2, TOut> When(Func<TIn1, TIn2, bool> predicate)
        {
            condition = condition && predicate.Invoke(in1, in2);
            return this;
        }

        protected override TOut ApplyFunctionAndGet()
        {
            return (result = Function.Invoke(in1, in2));
        }

        public Act<TIn1, TIn2, TOut> With(TIn1 in1, TIn2 in2)
        {
            this.in1 = in1;
            this.in2 = in2;
            return this;
        }
    }

    public class Act<TIn1, TIn2, TIn3, TOut> : Act<TOut>
    {
        private TIn1 in1;
        private TIn2 in2;
        private TIn3 in3;

        public Func<TIn1, TIn2, TIn3, TOut> Function { get; set; }

        public Act(TIn1 in1, TIn2 in2, TIn3 in3)
        {
            this.in1 = in1;
            this.in2 = in2;
            this.in3 = in3;
        }

        public Act(Func<TIn1, TIn2, TIn3, TOut> function)
        {
            this.Function = function;
        }

        public Act(Func<TIn1, TIn2, TIn3, TOut> function, TIn1 in1, TIn2 in2, TIn3 in3)
        {
            this.in1 = in1;
            this.in2 = in2;
            this.in3 = in3;
            this.Function = function;
        }

        public Act(Func<TIn1, TIn2, TIn3, TOut> function, TOut? result)
        {
            this.Function = function;
            this.result = result;
        }

        public Act<TIn1, TIn2, TIn3, TOut> When(Func<TIn1, TIn2, TIn3, bool> predicate)
        {
            condition = condition && predicate.Invoke(in1, in2, in3);
            return this;
        }

        protected override TOut ApplyFunctionAndGet()
        {
            return (result = Function.Invoke(in1, in2, in3));
        }

        public Act<TIn1, TIn2, TIn3, TOut> With(TIn1 in1, TIn2 in2, TIn3 in3)
        {
            this.in1 = in1;
            this.in2 = in2;
            this.in3 = in3;
            return this;
        }
    }

    public class Act<TIn1, TIn2, TIn3, TIn4, TOut> : Act<TOut>
    {
        private TIn1 in1;
        private TIn2 in2;
        private TIn3 in3;
        private TIn4 in4;
        

        public Func<TIn1, TIn2, TIn3, TIn4, TOut> Function { get; set; }

        public Act(TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4)
        {
            this.in1 = in1;
            this.in2 = in2;
            this.in3 = in3;
            this.in4 = in4;
        }

        public Act(Func<TIn1, TIn2, TIn3, TIn4, TOut> function)
        {
            this.Function = function;
        }

        public Act(Func<TIn1, TIn2, TIn3, TIn4, TOut> function, TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4)
        {
            this.in1 = in1;
            this.in2 = in2;
            this.in3 = in3;
            this.in4 = in4;
            this.Function = function;
        }

        public Act(Func<TIn1, TIn2, TIn3, TIn4, TOut> function, TOut? result)
        {
            this.Function = function;
            this.result = result;
        }

        public Act<TIn1, TIn2, TIn3, TIn4, TOut> When(Func<TIn1, TIn2, TIn3, TIn4, bool> predicate)
        {
            condition = condition && predicate.Invoke(in1, in2, in3, in4);
            return this;
        }

        protected override TOut ApplyFunctionAndGet()
        {
            return (result = Function.Invoke(in1, in2, in3, in4));
        }

        public Act<TIn1, TIn2, TIn3, TIn4, TOut> With(TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4)
        {
            this.in1 = in1;
            this.in2 = in2;
            this.in3 = in3;
            this.in4 = in4;
            return this;
        }
    }

    public class Act<TIn1, TIn2, TIn3, TIn4, TIn5, TOut> : Act<TOut>
    {
        private TIn1 in1;
        private TIn2 in2;
        private TIn3 in3;
        private TIn4 in4;
        private TIn5 in5;
        
        public Func<TIn1, TIn2, TIn3, TIn4, TIn5, TOut> Function { get; set; }

        public Act(TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4, TIn5 in5)
        {
            this.in1 = in1;
            this.in2 = in2;
            this.in3 = in3;
            this.in4 = in4;
            this.in5 = in5;
        }

        public Act(Func<TIn1, TIn2, TIn3, TIn4, TIn5, TOut> function)
        {
            this.Function = function;
        }

        public Act(Func<TIn1, TIn2, TIn3, TIn4, TIn5, TOut> function, TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4, TIn5 in5)
        {
            this.in1 = in1;
            this.in2 = in2;
            this.in3 = in3;
            this.in4 = in4;
            this.in5 = in5;
            this.Function = function;
        }

        public Act(Func<TIn1, TIn2, TIn3, TIn4, TIn5, TOut> function, TOut? result)
        {
            this.Function = function;
            this.result = result;
        }

        public Act<TIn1, TIn2, TIn3, TIn4, TIn5, TOut> When(Func<TIn1, TIn2, TIn3, TIn4, TIn5, bool> predicate)
        {
            condition = condition && predicate.Invoke(in1, in2, in3, in4, in5);
            return this;
        }

        protected override TOut ApplyFunctionAndGet()
        {
            return (result = Function.Invoke(in1, in2, in3, in4, in5));
        }

        public Act<TIn1, TIn2, TIn3, TIn4, TIn5, TOut> With(TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4)
        {
            this.in1 = in1;
            this.in2 = in2;
            this.in3 = in3;
            this.in4 = in4;
            return this;
        }
    }
}
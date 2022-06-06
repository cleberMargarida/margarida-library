using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Margarida.Util.Linq
{
    public class AwesomeAction<TIn>
    {
        protected bool condition = true;

        private TIn in1;

        public Action<TIn> Action { get; set; }

        public AwesomeAction(Action<TIn> action, TIn in1)
        {
            this.in1 = in1;
            this.Action = action;
        }

        public AwesomeAction<TIn> When(Func<TIn, bool> predicate)
        {
            condition = condition && predicate.Invoke(in1);
            return this;
        }

        public AwesomeAction<TIn> With(TIn in1)
        {
            this.in1 = in1;
            return this;
        }

        public void DoIt()
        {
            Action(in1);
        }
    }

    public class AwesomeAction<TIn1, TIn2>
    {
        protected bool condition = true;

        private TIn1 in1;
        private TIn2 in2;

        public Action<TIn1, TIn2> Action { get; set; }

        public AwesomeAction(Action<TIn1, TIn2> action, TIn1 in1, TIn2 in2)
        {
            this.in1 = in1;
            this.in2 = in2;
            this.Action = action;
        }

        public AwesomeAction<TIn1, TIn2> When(Func<TIn1, TIn2, bool> predicate)
        {
            condition = condition && predicate.Invoke(in1, in2);
            return this;
        }

        public AwesomeAction<TIn1, TIn2> With(TIn1 in1, TIn2 in2)
        {
            this.in1 = in1;
            this.in2 = in2;
            return this;
        }

        public void DoIt()
        {
            Action(in1, in2);
        }
    }

    public class AwesomeAction<TIn1, TIn2, TIn3>
    {
        protected bool condition = true;

        private TIn1 in1;
        private TIn2 in2;
        private TIn3 in3;

        public Action<TIn1, TIn2, TIn3> Action { get; set; }

        public AwesomeAction(Action<TIn1, TIn2, TIn3> action, TIn1 in1, TIn2 in2, TIn3 in3)
        {
            this.in1 = in1;
            this.in2 = in2;
            this.in3 = in3;
            this.Action = action;
        }

        public AwesomeAction<TIn1, TIn2, TIn3> When(Func<TIn1, TIn2, TIn3, bool> predicate)
        {
            condition = condition && predicate.Invoke(in1, in2, in3);
            return this;
        }

        public AwesomeAction<TIn1, TIn2, TIn3> With(TIn1 in1, TIn2 in2, TIn3 in3)
        {
            this.in1 = in1;
            this.in2 = in2;
            this.in3 = in3;
            return this;
        }

        public void DoIt()
        {
            Action(in1, in2, in3);
        }
    }

    public class AwesomeAction<TIn1, TIn2, TIn3, TIn4>
    {
        protected bool condition = true;

        private TIn1 in1;
        private TIn2 in2;
        private TIn3 in3;
        private TIn4 in4;
        public Action<TIn1, TIn2, TIn3, TIn4> Action { get; set; }

        public AwesomeAction(Action<TIn1, TIn2, TIn3, TIn4> action, TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4)
        {
            this.in1 = in1;
            this.in2 = in2;
            this.in3 = in3;
            this.in4 = in4;
            this.Action = action;
        }

        public AwesomeAction<TIn1, TIn2, TIn3, TIn4> When(Func<TIn1, TIn2, TIn3, TIn4, bool> predicate)
        {
            condition = condition && predicate.Invoke(in1, in2, in3, in4);
            return this;
        }

        public AwesomeAction<TIn1, TIn2, TIn3, TIn4> With(TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4)
        {
            this.in1 = in1;
            this.in2 = in2;
            this.in3 = in3;
            this.in4 = in4;
            return this;
        }

        public void DoIt()
        {
            Action(in1, in2, in3, in4);
        }
    }

    public class AwesomeAction<TIn1, TIn2, TIn3, TIn4,  TIn5>
    {
        protected bool condition = true;

        private TIn1 in1;
        private TIn2 in2;
        private TIn3 in3;
        private TIn4 in4;
        private TIn5 in5;

        public Action<TIn1, TIn2, TIn3, TIn4,  TIn5> Action { get; set; }

        public AwesomeAction(Action<TIn1, TIn2, TIn3, TIn4,  TIn5> action, TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4, TIn5 in5)
        {
            this.in1 = in1;
            this.in2 = in2;
            this.in3 = in3;
            this.in4 = in4;
            this.in5 = in5;
            this.Action = action;
        }

        public AwesomeAction<TIn1, TIn2, TIn3, TIn4,  TIn5> When(Func<TIn1, TIn2, TIn3, TIn4, TIn5, bool> predicate)
        {
            condition = condition && predicate.Invoke(in1, in2, in3, in4, in5);
            return this;
        }

        public AwesomeAction<TIn1, TIn2, TIn3, TIn4,  TIn5> With(TIn1 in1, TIn2 in2, TIn3 in3, TIn4 in4, TIn5 in5)
        {
            this.in1 = in1;
            this.in2 = in2;
            this.in3 = in3;
            this.in4 = in4;
            this.in5 = in5;
            return this;
        }

        public void DoIt()
        {
            Action(in1, in2, in3, in4, in5);
        }
    }
}

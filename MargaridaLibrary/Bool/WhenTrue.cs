using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Margarida.Util.Bool
{
    public class WhenTrue<T>
    {
        private bool passed;
        public T Value { get; private set; }

        public static implicit operator T?(WhenTrue<T> whenTrue)
        {
            if (whenTrue.passed) 
                return whenTrue.Value;

            return default;
        }

        public WhenTrue(T input, bool condition)
        {
            this.Value = input;
            this.passed = condition;
        }

        public WhenTrue(T input, Func<T, bool> condition)
        {
            this.Value = input;
            this.passed = condition(input);
        }

        public T WhenNot(T param)
        {
            return param;
        }
    }
}

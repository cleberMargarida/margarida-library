using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Margarida.Util.Bool
{
    public class WhenTrue<T>
    {
        private T? input;
        private bool passed;

        public static implicit operator T(WhenTrue<T> whenTrue)
        {
            if (whenTrue.passed) return whenTrue.input;
            return default;
        }

        public WhenTrue(T? input, bool condition)
        {
            this.input = input;
            this.passed = condition;
        }

        public T WhenNot(T info)
        {
            return info;
        }
    }
}

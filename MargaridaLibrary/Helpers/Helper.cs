using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Margarida.Util.Helpers
{
    public static class Helper
    {
        public static class Ex
        {
            public static AwesomeTryCat Try(Action action)
            {
                return new(action);
            }

            public static void ThrowArgumentException(string message)
            {
                throw new ArgumentException(message);
            }

            public static void ThrowArgumentNullException(string message)
            {
                throw new ArgumentNullException(message);
            }

            public static void ThrowInvalidOperationException(string message)
            {
                throw new InvalidOperationException(message);
            }

            public static void ThrowFileNotFoundException(string message)
            {
                throw new FileNotFoundException(message);
            }

            public static void ThrowFormatException(string message)
            {
                throw new FormatException(message);
            }
        }

        public static void Swap<T>(ref T a, ref T b)
        {
            T aux = a;
            a = b;
            b = aux;
        }
    }
}

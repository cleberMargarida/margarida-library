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
        }

        public static void Swap<T>(ref T a, ref T b)
        {
            T aux = a;
            a = b;
            b = aux;
        }
    }
}

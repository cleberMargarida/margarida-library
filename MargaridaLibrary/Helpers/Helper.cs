using Margarida.Util.Helpers.Internal;

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

            public static ArgumentException ThrowArgumentException(string message)
            {
                return new ArgumentException(message);
            }

            public static ArgumentNullException ThrowArgumentNullException(string message)
            {
                return new ArgumentNullException(message);
            }

            public static InvalidOperationException ThrowInvalidOperationException(string message)
            {
                return new InvalidOperationException(message);
            }

            public static FileNotFoundException ThrowFileNotFoundException(string message)
            {
                return new FileNotFoundException(message);
            }

            public static FormatException ThrowFormatException(string message)
            {
                return new FormatException(message);
            }


            public static NotImplementedException ThrowNotImplementedException(string message)
            {
                return new NotImplementedException(message);
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

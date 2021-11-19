using Margarida.Util.Bool;
using System.Collections;

namespace Margarida.Util.Type
{
    public static class TypeExt
    {
        public static bool IsDefault(this object obj)
        {
            switch (obj)
            {
                case var o when obj is int:
                    return o as int? == default(int);

                case var o when obj is string:
                    return string.IsNullOrEmpty(o as string);

                case var o when obj is bool:
                    return o as bool? == default(bool);

                case var o when obj is long:
                    return o as long? == default(long);

                case var o when obj is char:
                    return o as char? == default(char);

                default: return obj == null;
            }
        }

        public static bool HasValue(this object? obj)
        {
            if (obj == null)
                return false;

            var type = obj.GetType();

            if (type.IsPrimitive || type is string)
                return obj.Not(IsDefault);

            if (obj is IEnumerable)
                return type?.GetProperty("Length")?
                            .GetValue(obj) as int? is not default(int) and not null;

            return type.GetProperties().Any(p => HasValue(p.GetValue(obj)));
        }
    }
}

using Margarida.Util.Attributes;
using Margarida.Util.Bool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable CS8603 // Possible null reference return.

namespace Margarida.Util.Enum
{
    public static class EnumExt
    {
        public static string GetDescription<T> (this T value)
            where T : struct, IConvertible
        {
            var attribute = value.GetAttributeFromEnum<T, DescriptionAttribute>();

            if (attribute is null) 
                throw new Exception($"The member of {typeof(T).Name} has not marked with \'Description\' attribute.");

            return attribute.Description;
        }

        public static TAttribute GetAttributeFromEnum<T, TAttribute>(this T value)
            where T : struct, IConvertible
            where TAttribute : Attribute
        {
            var enumType = value.GetType();
            var name = System.Enum.GetName(enumType, value);

            return default(TAttribute)
                .When(name is null)
                .WhenNot(enumType
                    .GetField(name)?
                    .GetCustomAttributes(false)
                    .OfType<TAttribute>()
                    .SingleOrDefault());
        }
    }
}
#pragma warning restore CS8603 // Possible null reference return.

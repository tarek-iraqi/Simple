using System;
using System.Linq;

namespace Simple.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Retrieve any attribute data associated with enum type whether it is built in attribute custom attribute
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="value"></param>
        /// <returns>The attribute type object or null if the attribute not exist</returns>
        public static TAttribute GetAttribute<TAttribute>(this Enum value)
            where TAttribute : Attribute
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            return type.GetField(name ?? string.Empty)?.GetCustomAttributes(false)
                .OfType<TAttribute>()
                .SingleOrDefault();
        }
    }
}
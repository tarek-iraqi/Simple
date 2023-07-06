using System;
using System.Text.Json;

namespace Simple.Extensions
{
    public static class GenericTypeExtensions
    {
        /// <summary>
        /// Converts the provided value into a <see cref="string"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance">The value to convert</param>
        /// <param name="options">Options to control the conversion behavior</param>
        /// <returns>A <see cref="string"/> representation of the value</returns>
        public static string ToJson<T>(this T instance, JsonSerializerOptions options = null)
            => instance == null
            ? throw new ArgumentNullException(nameof(instance))
            : JsonSerializer.Serialize(instance, options);
    }
}

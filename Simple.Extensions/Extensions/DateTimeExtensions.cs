using System;

namespace Simple.Extensions
{
    public static class DateTimeExtensions
    {
        private static readonly DateTime _unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Convert valid DateTime to unix timestamp
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>Long value represent DateTime in unix timestamp</returns>
        public static long ToUnixTimeStamp(this DateTime dateTime)
        {
            return (long)(dateTime - _unixEpoch).TotalSeconds;
        }
    }
}

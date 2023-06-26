using System;

namespace Simple.Extensions
{
    public static class LongExtensions
    {
        private static readonly DateTime _unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Convert from unix timestamp to valid DateTime
        /// </summary>
        /// <param name="unixEpoch"></param>
        /// <returns>New DateTime represent the unix timestamp</returns>
        public static DateTime FromUnixTimeStampToDateTime(this long unixEpoch)
        {
            return _unixEpoch.AddSeconds(unixEpoch);
        }
    }
}
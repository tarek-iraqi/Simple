using System;
using System.Collections.Generic;

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

        /// <summary>
        /// Create a DateTime range between from and to
        /// </summary>
        /// <param name="fromDate">The start date of the range</param>
        /// <param name="toDate">The end date of the range</param>
        /// <param name="inclusiveStartAndEnd">Specify whether to include start and end dates in the range, default is true</param>
        /// <returns>An <see cref="IEnumerable{DateTime}"/> collection of dates</returns>
        public static IEnumerable<DateTime> GetDateRangeTo(this DateTime fromDate, DateTime toDate, bool inclusiveStartAndEnd = true)
        {
            if (toDate < fromDate) throw new ArgumentOutOfRangeException(nameof(toDate));

            int days = (toDate - fromDate).Days;
            int start = inclusiveStartAndEnd ? 0 : 1;
            int end = inclusiveStartAndEnd ? days : days - 1;

            for (var i = start; i <= end; i++)
                yield return fromDate.AddDays(i);
        }
    }


}

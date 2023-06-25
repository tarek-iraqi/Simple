using System;

public static class DateTimeExtensions
{
    private static readonly DateTime _unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
    public static long ToUnixTimeStamp(this DateTime dateTime)
    {
        return (long)(dateTime - _unixEpoch).TotalSeconds;
    }
}

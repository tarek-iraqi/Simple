using System;

public static class LongExtensions
{
    private static readonly DateTime _unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

    public static DateTime FromUnixTimeStampToDateTime(this long unixEpoch)
    {
        return _unixEpoch.AddSeconds(unixEpoch);
    }
}
using System.Globalization;

namespace Simple.Extensions.Testing;
public class LongExtensionsTests
{
    [Theory]
    [InlineData(1687634943, "2023-06-24 07:29:03 PM")]
    [InlineData(0, "1970-01-01 12:00:00 AM")]
    [InlineData(467769600, "1984-10-28 12:00:00 AM")]
    [InlineData(-12155011200, "1584-10-28 12:00:00 AM")]
    public void FromUnixTimeStampToDateTime_ReturnValidDateTime(long input, string expected)
    {
        var date = input.FromUnixTimeStampToDateTime();

        Assert.Equal(expected, date.ToString("yyyy-MM-dd hh:mm:ss tt", CultureInfo.InvariantCulture));
    }
}

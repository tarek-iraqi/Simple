using System.Globalization;

namespace Simple.Extensions.Testing;
public class DateTimeExtensionsTests
{
    [Theory]
    [InlineData("2023-06-24 07:29:03 pm", 1687634943)]
    [InlineData("1970-01-01 12:00:00 am", 0)]
    [InlineData("1984-10-28 12:00:00 am", 467769600)]
    [InlineData("1584-10-28 12:00:00 am", -12155011200)]
    public void ToUnixTimeStamp_ReturnValidNumber(string input, long expected)
    {
        var date = DateTime.Parse(input, CultureInfo.InvariantCulture);

        Assert.Equal(expected, date.ToUnixTimeStamp());
    }
}

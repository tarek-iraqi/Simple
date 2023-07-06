using FluentAssertions;
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

    [Fact]
    public void GetDateRangeTo_InvlaidEndDate_ThrowException()
    {
        var date = new DateTime(2023, 7, 6);

        var act = () => date.GetDateRangeTo(new DateTime(2023, 7, 5)).ToList();

        act.Should().Throw<ArgumentOutOfRangeException>()
            .WithParameterName("toDate");
    }

    [Fact]
    public void GetDateRangeTo_VlaidEndDateWithInclusiveStartAndEnd_ReturnDateRange()
    {
        var start = new DateTime(2023, 7, 6);
        var end = new DateTime(2023, 7, 15);

        var range = start.GetDateRangeTo(end).ToList();

        range.Should().HaveCount(10);
        range.First().Should().Be(start);
        range.Last().Should().Be(end);
    }

    [Fact]
    public void GetDateRangeTo_VlaidEndDateWithExeclusiveStartAndEnd_ReturnDateRange()
    {
        var start = new DateTime(2023, 7, 6);
        var end = new DateTime(2023, 7, 15);

        var range = start.GetDateRangeTo(end, false).ToList();

        range.Should().HaveCount(8);
        range.First().Should().Be(start.AddDays(1));
        range.Last().Should().Be(end.AddDays(-1));
    }
}

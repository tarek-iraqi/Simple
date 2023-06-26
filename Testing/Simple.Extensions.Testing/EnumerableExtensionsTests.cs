using FluentAssertions;
using Simple.Extensions.Testing.Helpers;

namespace Simple.Extensions.Testing;

public class EnumerableExtensionsTests
{
    [Fact]
    public void WhereIf_TrueCondition_FilterTheData()
    {
        var data = SampleData.GetSampleUsers(30).ToList();

        var result = data.WhereIf(u => u.Id % 2 == 0, () => 1 == 1);

        result.Count().Should().Be(15);
    }

    [Fact]
    public void WhereIf_FalseCondition_NoFilterApplied()
    {
        var data = SampleData.GetSampleUsers(30).ToList();

        var result = data.WhereIf(u => u.Id % 2 == 0, () => 1 == 2);

        result.Count().Should().Be(30);
    }
}

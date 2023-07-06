using FluentAssertions;
using Simple.Extensions.Testing.Helpers;

namespace Simple.Extensions.Testing;
public class GenericTypeExtensionsTests
{
    [Fact]
    public void ToJson_EmptyValue_ThrowException()
    {
        SampleData.Person user = null!;

        var act = () => user.ToJson();

        act.Should().Throw<ArgumentNullException>().WithParameterName("instance");
    }

    [Fact]
    public void ToJson_ObjectValue_ConvertToJsonString()
    {
        SampleData.Person user = new(1, "tarek");

        var result = user.ToJson();

        result.Should().Be(""""{"Id":1,"Name":"tarek"}"""");
    }
}

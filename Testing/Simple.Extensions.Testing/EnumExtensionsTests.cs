using FluentAssertions;
using Simple.Extensions.Testing.Helpers;
using System.ComponentModel;

namespace Simple.Extensions.Testing;
public class EnumExtensionsTests
{
    [Fact]
    public void GetAttribute_ReturnAttributeValue()
    {
        var typeDescription = SampleData.Types.TypeA.GetAttribute<DescriptionAttribute>().Description;

        typeDescription.Should().Be("This is type A");
    }

    [Fact]
    public void GetAttribute_EnumHasNoAttribute_ReturnNull()
    {
        var typeDescription = SampleData.Types.TypeB.GetAttribute<DescriptionAttribute>()?.Description;

        typeDescription.Should().BeNull();
    }
}

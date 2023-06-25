namespace Simple.Extensions.Testing;

public class StringExtensionsTests
{
    [Theory]
    [InlineData("")]
    public void IsEmpty_ReturnTrue(string str)
    {
        Assert.True(str.IsEmpty());
    }

    [Theory]
    [InlineData(" ")]
    [InlineData(null)]
    [InlineData("abz")]
    [InlineData("a")]
    public void IsEmpty_ReturnFalse(string str)
    {
        Assert.False(str.IsEmpty());
    }

    [Fact]
    public void IsNull_ReturnTrue()
    {
        string? str = null;

        Assert.True(str.IsNull());
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("abz")]
    [InlineData("a")]
    public void IsNull_ReturnFasle(string str)
    {
        Assert.False(str.IsNull());
    }

    [Theory]
    [InlineData(" ")]
    [InlineData("  ")]
    [InlineData("   ")]
    public void IsWhiteSpace_ReturnTrue(string str)
    {
        Assert.True(str.IsWhiteSpace());
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("a")]
    [InlineData("abc")]
    public void IsWhiteSpace_ReturnFalse(string str)
    {
        Assert.False(str.IsWhiteSpace());
    }

    [Theory]
    [InlineData("a")]
    [InlineData("abc")]
    public void HasValue_ReturnTrue(string str)
    {
        Assert.True(str.HasValue());
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("  ")]
    public void HasValue_ReturnFalse(string str)
    {
        Assert.False(str.HasValue());
    }

    [Theory]
    [InlineData("", "")]
    [InlineData(null, null)]
    [InlineData("   ", "   ")]
    [InlineData("~`!@#$%^&*()-_+={}[]|\\/:,<>;.?'\"", "")]
    [InlineData("abc efg", "abc efg")]
    [InlineData("abc-efg", "abcefg")]
    [InlineData("[a]bc-[e]f(g)", "abcefg")]
    [InlineData("[a]bc<><><>[e]f(g)", "abcefg")]
    public void RemoveSpecialCharacters_ReturnValidString(string str, string expected)
    {
        Assert.Equal(expected, str.RemoveSpecialCharacters());
    }

    [Theory]
    [InlineData("", "")]
    [InlineData(null, null)]
    [InlineData("   ", "")]
    [InlineData("~`!@#$%^&*()-_+={}[]|\\/:,<>;.?'\"", "")]
    [InlineData("abc efg", "abcefg")]
    [InlineData("abc-efg", "abcefg")]
    [InlineData("[a]bc-[e]f(g)", "abcefg")]
    [InlineData("[a]bc<><><>[e]f(g)", "abcefg")]
    public void RemoveSpecialCharactersAndSpaces_ReturnValidString(string str, string expected)
    {
        Assert.Equal(expected, str.RemoveSpecialCharactersAndSpaces());
    }

    [Theory]
    [InlineData("", "")]
    [InlineData(null, null)]
    [InlineData("   ", "")]
    [InlineData("~`!@#$%^&*()-_+={}[]|\\/:,<>;.?'\"", "~`!@#$%^&*()-_+={}[]|\\/:,<>;.?'\"")]
    [InlineData("abc efg", "abcefg")]
    [InlineData("abc-efg", "abc-efg")]
    [InlineData("[a]bc-[  e  ]f(g)", "[a]bc-[e]f(g)")]
    [InlineData("[a]bc<>  <> <>[e]f(g)", "[a]bc<><><>[e]f(g)")]
    public void RemoveSpaces_ReturnValidString(string str, string expected)
    {
        Assert.Equal(expected, str.RemoveSpaces());
    }
}
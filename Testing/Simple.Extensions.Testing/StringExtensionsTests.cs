using FluentAssertions;

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

    [Theory]
    [InlineData("", false)]
    [InlineData(null, false)]
    [InlineData("   ", false)]
    [InlineData("~`!@#$%^&*()-_+={}[]|\\/:,<>;.?'\"", true)]
    [InlineData("abc efg", false)]
    [InlineData("abc-efg", true)]
    [InlineData("[a]bc<>  <> <>[e]f(g)", true)]
    [InlineData("abcdefg", false)]
    [InlineData("abcdefg1234", false)]
    [InlineData("122344", false)]
    public void HasSpecialCharacters_ReturnValidBoolen(string str, bool expected)
    {
        str.HasSpecialCharacters().Should().Be(expected);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData(null, false)]
    [InlineData("   ", true)]
    [InlineData("~`!@#$%^&*()-_+={}[]|\\/:,<>;.?'\"", false)]
    [InlineData("abc efg", true)]
    [InlineData("abc-efg", false)]
    [InlineData("[a]bc<>  <> <>[e]f(g)", true)]
    [InlineData("abcdefg", false)]
    [InlineData("abcdefg1234", false)]
    [InlineData("122344", false)]
    public void HasSpaces_ReturnValidBoolen(string str, bool expected)
    {
        str.HasSpaces().Should().Be(expected);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData(null, false)]
    [InlineData("   ", true)]
    [InlineData("~`!@#$%^&*()-_+={}[]|\\/:,<>;.?'\"", true)]
    [InlineData("abc efg", true)]
    [InlineData("abc-efg", true)]
    [InlineData("[a]bc<>  <> <>[e]f(g)", true)]
    [InlineData("abcdefg", false)]
    [InlineData("abcdefg1234", false)]
    [InlineData("122344", false)]
    public void HasSpecialCharactersOrSpaces_ReturnValidBoolen(string str, bool expected)
    {
        str.HasSpecialCharactersOrSpaces().Should().Be(expected);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("   ")]
    [InlineData("~`!@#$%^&*()-_+={}[]|\\/:,<>;.?'\"")]
    [InlineData("abc efg")]
    [InlineData("abc-efg")]
    [InlineData("[a]bc<>  <> <>[e]f(g)")]
    [InlineData("abcdefg")]
    [InlineData("122344")]
    [InlineData("https:/nuget.org/packages/Simple.Extensions")]
    [InlineData("https://googlecom")]
    [InlineData("://google.com")]
    [InlineData("https//google.com")]
    public void IsValidUrl_InvalidUrl_ReturnFalse(string str)
    {
        str.IsValidUrl().Should().BeFalse();
    }

    [Theory]
    [InlineData("https://www.nuget.org")]
    [InlineData("https://nuget.org/packages/Simple.Extensions")]
    [InlineData("http://nuget.org/packages/Simple.Extensions")]
    [InlineData("https://google.com")]
    [InlineData("https://google.com/")]
    [InlineData("https://google.com?")]
    [InlineData("https://google.com?name=ahmed")]
    [InlineData("https://google.com/#")]
    [InlineData("https://google.com/#index")]
    public void IsValidUrl_ValidUrl_ReturnTrue(string str)
    {
        str.IsValidUrl().Should().BeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("   ")]
    [InlineData("~`!@#$%^&*()-_+={}[]|\\/:,<>;.?'\"")]
    [InlineData("abc efg")]
    [InlineData("abc-efg")]
    [InlineData("[a]bc<>  <> <>[e]f(g)")]
    [InlineData("abcdefg")]
    [InlineData("122344")]
    [InlineData("https:/nuget.org/packages/Simple.Extensions")]
    [InlineData("https://googlecom")]
    [InlineData("://google.com")]
    [InlineData("https//google.com")]
    [InlineData("abcd https//google.com efg")]
    public void ExtractUrls_InvalidUrl_ReturnEmptyCollection(string str)
    {
        str.ExtractUrls().Should().BeEmpty();
    }

    [Theory]
    [InlineData("https://google.com", 1)]
    [InlineData("abchttps://google.comefg", 1)]
    [InlineData("abc https://google.com efg", 1)]
    [InlineData("abc https://google.com efg vvv https://google.com mmm", 2)]
    [InlineData("abc https://google.com efg vvv https://google.com mmm mmm http://nuget.org/packages/Simple.Extensions", 3)]
    public void ExtractUrls_ValidUrl_ReturnUrlsCollection(string str, int expected)
    {
        var result = str.ExtractUrls();
        result.Should().NotBeEmpty();
        result.Should().HaveCount(expected);
    }

    [Fact]
    public void ExtractUrls_ValidUrl_ReturnExpectedUrls()
    {
        var str = "abchttps://google.com efg vvv https://google.commmm mmm " +
            "http://nuget.org/packages/Simple.Extensions?name=amed ddddd " +
            "https://google.com?#index";

        var result = str.ExtractUrls();
        result.Should().NotBeEmpty();
        result.Should().HaveCount(4);
        result.Should().BeEquivalentTo(new[] {
            "https://google.com?#index",
            "https://google.com",
            "https://google.commmm",
            "http://nuget.org/packages/Simple.Extensions?name=amed"
        });
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("   ")]
    [InlineData("~`!@#$%^&*()-_+={}[]|\\/:,<>;.?'\"")]
    [InlineData("abc efg")]
    [InlineData("abc-efg")]
    [InlineData("[a]bc<>  <> <>[e]f(g)")]
    [InlineData("abcdefg")]
    [InlineData("122344")]
    [InlineData("ahmed@example")]
    [InlineData("://google.com")]
    [InlineData("https//google.com")]
    [InlineData("ahmed@example..com")]
    [InlineData(".ahmed@example.com")]
    [InlineData("ahmed#ali@example.com")]
    [InlineData("ahmed..ali@example.com")]
    [InlineData("ahmed/ali@example.com")]
    [InlineData("ahmed[]ali@example.com")]
    [InlineData("#ahmed.ali@example.com")]
    [InlineData("ahmed.ali@example.com.")]
    [InlineData("ahmed.ali@example..com")]
    [InlineData("ahmed.ali@@example.com")]
    [InlineData("ahmed.ali@example.com#")]
    [InlineData("ahmed.ali@example.com@gmail.com")]
    [InlineData("ahmed.ali.@example.com")]
    [InlineData(".ahmed.ali.@example.com")]
    [InlineData("-ahmed.ali.@example.com")]
    [InlineData("_ahmed.ali.@example.com")]
    public void IsValidEmail_InvalidEmail_ReturnFalse(string str)
    {
        str.IsValidEmail().Should().BeFalse();
    }

    [Theory]
    [InlineData("ahmed@example.com")]
    [InlineData("ahmed.ali@example.com")]
    [InlineData("ahmed.ali.mahmoud@example.com")]
    [InlineData("ahmed-ali@example.com")]
    [InlineData("ahmed-ali-mahmoud@example.com")]
    [InlineData("ahmed_ali@example.com")]
    [InlineData("ahmed_ali_mahmoud@example.com")]
    [InlineData("ahmed.ali_mahmoud@example.com")]
    [InlineData("ahmed.123@example.com")]
    [InlineData("123ahmed@example.com")]
    [InlineData("123.ahmed@example.com")]
    [InlineData("123-ahmed@example.com")]
    [InlineData("123-ahmed@456.com")]
    [InlineData("hello@192.168.0.1")]
    [InlineData("hello@GMAIL.Com")]
    [InlineData("ALI@EMAIL.COM")]
    public void IsValidEmail_ValidEmail_ReturnTrue(string str)
    {
        str.IsValidEmail().Should().BeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("   ")]
    [InlineData("~`!@#$%^&*()-_+={}[]|\\/:,<>;.?'\"")]
    [InlineData("abc efg")]
    [InlineData("abc-efg")]
    [InlineData("[a]bc<>  <> <>[e]f(g)")]
    [InlineData("abcdefg")]
    [InlineData("122344")]
    [InlineData("ahmed@example")]
    [InlineData("://google.com")]
    [InlineData("https//google.com")]
    [InlineData("ahmed@example..com")]
    [InlineData("ahmed.ali@example..com")]
    [InlineData("ahmed.ali@@example.com")]
    [InlineData("ahmed.ali.@example.com")]
    [InlineData(".ahmed.ali.@example.com")]
    [InlineData("-ahmed.ali.@example.com")]
    [InlineData("_ahmed.ali.@example.com")]
    public void ExtractEmails_InvalidEmail_ReturnEmptyCollection(string str)
    {
        str.ExtractEmails().Should().BeEmpty();
    }

    [Theory]
    [InlineData(".ahmed@example.com", "ahmed@example.com")]
    [InlineData("ahmed#ali@example.com", "ali@example.com")]
    [InlineData("ahmed..ali@example.com", "ali@example.com")]
    [InlineData("ahmed/ali@example.com", "ali@example.com")]
    [InlineData("ahmed[]ali@example.com", "ali@example.com")]
    [InlineData("#ahmed.ali@example.com", "ahmed.ali@example.com")]
    [InlineData("ahmed.ali@example.com.", "ahmed.ali@example.com")]
    [InlineData("ahmed.ali@example.com#", "ahmed.ali@example.com")]
    [InlineData("ahmed.ali@example.com@gmail.com", "ahmed.ali@example.com")]
    [InlineData("hello@GMAIL.Com", "hello@GMAIL.Com")]
    [InlineData("ALI@EMAIL.COM", "ALI@EMAIL.COM")]
    [InlineData("anscdddahmed.ali@example.comgmail132", "anscdddahmed.ali@example.comgmail132")]
    [InlineData("welcome ahmed.ali@example.com in our", "ahmed.ali@example.com")]
    public void ExtractEmails_ValidEmail_ReturnExpectedEmail(string str, string expected)
    {
        var result = str.ExtractEmails();
        result.Should().NotBeEmpty();
        result.Should().Contain(expected);
    }

    [Fact]
    public void ExtractEmails_ValidEmail_ReturnExpectedEmails()
    {
        var str = " welcome ahmed@gmail.com in our website whereAli@outlook.org is glad to meet you again with" +
            " moustafa@koko and vivi@koko.net";

        var result = str.ExtractEmails();
        result.Should().NotBeEmpty();
        result.Should().BeEquivalentTo(new[] { "ahmed@gmail.com", "whereAli@outlook.org", "vivi@koko.net" });
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("   ")]
    [InlineData("~`!@#$%^&*()-_+={}[]|\\/:,<>;.?'\"")]
    [InlineData("abcd")]
    [InlineData("abcd<")]
    [InlineData("abcd <>")]
    [InlineData("abcd <h1/)")]
    public void HasHTMLTags_TextWithNoHTML_ReturnFalse(string str)
    {
        str.HasHTMLTags().Should().BeFalse();
    }

    [Theory]
    [InlineData("abcd <h1/>")]
    [InlineData("<div>hello world</div>")]
    [InlineData(" <div> hello world </div> ")]
    [InlineData("abcd <h1>")]
    [InlineData("abcd <    h1   >")]
    [InlineData("abcd <    h1   /    >")]
    [InlineData("<h1> abcd")]
    public void HasHTMLTags_TextWithHTML_ReturnTrue(string str)
    {
        str.HasHTMLTags().Should().BeTrue();
    }

    [Theory]
    [InlineData("", "")]
    [InlineData(null, null)]
    [InlineData("   ", "   ")]
    [InlineData("~`!@#$%^&*()-_+={}[]|\\/:,<>;.?'\"", "~`!@#$%^&*()-_+={}[]|\\/:,<>;.?'\"")]
    [InlineData("abcd", "abcd")]
    [InlineData("abcd<", "abcd<")]
    [InlineData("abcd <>", "abcd <>")]
    [InlineData("abcd <h1/)", "abcd <h1/)")]
    public void RemoveHTMLTags_TextWithNoHTML_ReturnSameText(string str, string expected)
    {
        str.RemoveHTMLTags().Should().Be(expected);
    }

    [Theory]
    [InlineData("abcd <h1/>", "abcd ")]
    [InlineData("<div>hello world</div>", "hello world")]
    [InlineData(" <div> hello world </div> ", "  hello world  ")]
    [InlineData("abcd <h1>", "abcd ")]
    [InlineData("abcd <    h1   >", "abcd ")]
    [InlineData("abcd <    h1   /    >", "abcd ")]
    [InlineData("<h1> abcd", " abcd")]
    public void RemoveHTMLTags_TextWithHTML_ReturnTextWithoutHTML(string str, string expected)
    {
        str.RemoveHTMLTags().Should().Be(expected);
    }
}
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

    [Fact]
    public void WhereIf_SourceIsNull_ThrowArgumentNullException()
    {
        IEnumerable<SampleData.Person> data = default;

        Action act = () => data.WhereIf(u => u.Id % 2 == 0, () => 1 == 2).ToList();

        act.Should().Throw<ArgumentNullException>()
            .WithParameterName("source")
            .WithMessage("Value cannot be null. (Parameter 'source')");
    }

    [Fact]
    public void WhereIf_PredicateIsNull_ThrowArgumentNullException()
    {
        var data = SampleData.GetSampleUsers(30).ToList();

        Func<SampleData.Person, bool> predicate = null;

        Action act = () => data.WhereIf(predicate, () => 1 == 2).ToList();

        act.Should().Throw<ArgumentNullException>()
            .WithParameterName("predicate")
            .WithMessage("Value cannot be null. (Parameter 'predicate')");
    }

    [Fact]
    public void WhereIf_ApplyPredicateIsNull_ThrowArgumentNullException()
    {
        var data = SampleData.GetSampleUsers(30).ToList();

        Func<bool> applyPredicate = null;

        Action act = () => data.WhereIf(u => u.Id % 2 == 0, applyPredicate).ToList();

        act.Should().Throw<ArgumentNullException>()
            .WithParameterName("applyPredicate")
            .WithMessage("Value cannot be null. (Parameter 'applyPredicate')");
    }
}

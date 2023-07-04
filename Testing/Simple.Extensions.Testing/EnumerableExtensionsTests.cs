using FluentAssertions;
using Simple.Extensions.Testing.Helpers;
using System.Diagnostics.CodeAnalysis;

namespace Simple.Extensions.Testing;

[ExcludeFromCodeCoverage]
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
        IEnumerable<SampleData.Person>? data = default;

        Action act = () => data.WhereIf(u => u.Id % 2 == 0, () => 1 == 2).ToList();

        act.Should().Throw<ArgumentNullException>()
            .WithParameterName("source")
            .WithMessage("Value cannot be null. (Parameter 'source')");
    }

    [Fact]
    public void WhereIf_PredicateIsNull_ThrowArgumentNullException()
    {
        var data = SampleData.GetSampleUsers(30).ToList();

        Func<SampleData.Person, bool>? predicate = null;

        Action act = () => data.WhereIf(predicate, () => 1 == 2).ToList();

        act.Should().Throw<ArgumentNullException>()
            .WithParameterName("predicate")
            .WithMessage("Value cannot be null. (Parameter 'predicate')");
    }

    [Fact]
    public void WhereIf_ApplyPredicateIsNull_ThrowArgumentNullException()
    {
        var data = SampleData.GetSampleUsers(30).ToList();

        Func<bool>? applyPredicate = null;

        Action act = () => data.WhereIf(u => u.Id % 2 == 0, applyPredicate).ToList();

        act.Should().Throw<ArgumentNullException>()
            .WithParameterName("applyPredicate")
            .WithMessage("Value cannot be null. (Parameter 'applyPredicate')");
    }

    [Fact]
    public void HasDuplicates_SequeceContainDuplicates_ReturnTrue()
    {
        var data = new int[] { 1, 2, 3, 4, 2, 4, 5, 6, 7 };

        var result = data.HasDuplicates();

        result.Should().BeTrue();
    }

    [Fact]
    public void HasDuplicates_SequeceWithNoDuplicates_ReturnFalse()
    {
        var data = new int[] { 1, 2, 3, 4, 5, 6, 7 };

        var result = data.HasDuplicates();

        result.Should().BeFalse();
    }

    [Fact]
    public void HasDuplicates_EmptySequence_ReturnFalse()
    {
        var data = Array.Empty<int>();

        var result = data.HasDuplicates();

        result.Should().BeFalse();
    }

    [Fact]
    public void HasDuplicates_DuplicateObjectSequence_ReturnTrue()
    {
        var result = SampleData.DuplicateUsers.HasDuplicates();

        result.Should().BeTrue();
    }

    [Fact]
    public void HasDuplicates_UniqueObjectSequence_ReturnFalse()
    {
        var result = SampleData.UniqueUsers.HasDuplicates();

        result.Should().BeFalse();
    }

    [Fact]
    public void HasDuplicates_SourceIsNull_ThrowArgumentNullException()
    {
        IEnumerable<int>? data = default;

        Action act = () => data.HasDuplicates();

        act.Should().Throw<ArgumentNullException>()
            .WithParameterName("source")
            .WithMessage("Value cannot be null. (Parameter 'source')");
    }

    [Fact]
    public void FindDuplicates_EmptySequence_ReturnEmptySequence()
    {
        var data = Array.Empty<int>();

        var result = data.FindDuplicates();

        result.Count().Should().Be(0);
    }

    [Fact]
    public void FindDuplicates_SequeceContainDuplicates_ReturnSequenceWithDuplicateElements()
    {
        var data = new int[] { 1, 2, 3, 4, 2, 4, 5, 6, 7 };

        var result = data.FindDuplicates();

        result.Count().Should().Be(2);
        result.Should().Contain(2);
        result.Should().Contain(4);
    }

    [Fact]
    public void FindDuplicates_SequeceWithNoDuplicates_ReturnEmptySequence()
    {
        var data = new int[] { 1, 2, 3, 4, 5, 6, 7 };

        var result = data.FindDuplicates();

        result.Count().Should().Be(0);
    }

    [Fact]
    public void FindDuplicates_DuplicateObjectSequence_ReturnDuplicateObjects()
    {
        var result = SampleData.DuplicateUsers.FindDuplicates();

        result.Count().Should().Be(2);
        result.Should().Contain(new User { Id = 1, Name = "a" });
        result.Should().Contain(new User { Id = 2, Name = "e" });
    }

    [Fact]
    public void FindDuplicates_UniqueObjectSequence_ReturnEmptySequence()
    {
        var result = SampleData.UniqueUsers.FindDuplicates();

        result.Count().Should().Be(0);
    }

    [Fact]
    public void FindDuplicates_SourceIsNull_ThrowArgumentNullException()
    {
        IEnumerable<int>? data = null;

        Action act = () => data.FindDuplicates().ToList();

        act.Should().Throw<ArgumentNullException>()
            .WithParameterName("source")
            .WithMessage("Value cannot be null. (Parameter 'source')");
    }

    [Fact]
    public void RemoveDuplicates_SequeceWithNoDuplicates_ReturnOriginalSequence()
    {
        var data = new int[] { 1, 2, 3, 4, 5, 6, 7 };

        var result = data.RemoveDuplicates();

        result.Count().Should().Be(data.Length);
    }

    [Fact]
    public void RemoveDuplicates_EmptySequence_ReturnEmptySequence()
    {
        var data = Array.Empty<int>();

        var result = data.RemoveDuplicates();

        result.Count().Should().Be(0);
    }

    [Fact]
    public void RemoveDuplicates_SequeceContainDuplicates_ReturnSequenceWithUniqueElements()
    {
        var data = new int[] { 1, 2, 3, 4, 2, 4, 5, 6, 7 };

        var result = data.RemoveDuplicates();

        result.Count().Should().Be(data.Length - 2);
        result.Should().Contain(1);
        result.Should().Contain(2);
        result.Should().Contain(3);
        result.Should().Contain(4);
        result.Should().Contain(5);
        result.Should().Contain(6);
        result.Should().Contain(7);
    }

    [Fact]
    public void RemoveDuplicates_DuplicateObjectSequence_ReturnSequenceWithUniqueElements()
    {
        var result = SampleData.DuplicateUsers.RemoveDuplicates();

        result.Count().Should().Be(SampleData.DuplicateUsers.Count() - 2);
        result.Should().Contain(new User() { Id = 1, Name = "a" });
        result.Should().Contain(new User() { Id = 2, Name = "b" });
        result.Should().Contain(new User() { Id = 3, Name = "c" });
        result.Should().Contain(new User() { Id = 4, Name = "d" });
    }

    [Fact]
    public void RemoveDuplicates_UniqueObjectSequence_ReturnOriginalSequence()
    {
        var result = SampleData.UniqueUsers.RemoveDuplicates();

        result.Count().Should().Be(SampleData.UniqueUsers.Count());
        result.Should().Contain(new User() { Id = 1, Name = "a" });
        result.Should().Contain(new User() { Id = 2, Name = "b" });
        result.Should().Contain(new User() { Id = 3, Name = "c" });
        result.Should().Contain(new User() { Id = 4, Name = "d" });
    }

    [Fact]
    public void RemoveDuplicates_SourceIsNull_ThrowArgumentNullException()
    {
        IEnumerable<int>? data = default;

        Action act = () => data.RemoveDuplicates().ToList();

        act.Should().Throw<ArgumentNullException>()
            .WithParameterName("source")
            .WithMessage("Value cannot be null. (Parameter 'source')");
    }

    [Fact]
    public void CountDuplicates_SequeceWithNoDuplicates_ReturnEmptyDic()
    {
        var data = new int[] { 1, 2, 3, 4, 5, 6, 7 };

        var result = data.CountDuplicates();

        result.Count.Should().Be(0);
    }

    [Fact]
    public void CountDuplicates_EmptySequence_ReturnEmptyDic()
    {
        var data = Array.Empty<int>();

        var result = data.CountDuplicates();

        result.Count.Should().Be(0);
    }

    [Fact]
    public void CountDuplicates_SequeceContainDuplicates_ReturnDuplicatesWithCount()
    {
        var data = new int[] { 1, 2, 3, 4, 2, 4, 5, 6, 7 };

        var result = data.CountDuplicates();

        result.Count.Should().Be(2);
        result.Should().Contain(new KeyValuePair<int, int>(2, 2));
        result.Should().Contain(new KeyValuePair<int, int>(4, 2));
    }

    [Fact]
    public void CountDuplicates_DuplicateObjectSequence_ReturnDuplicatesWithCount()
    {
        var result = SampleData.DuplicateUsers.CountDuplicates();

        result.Count.Should().Be(2);
        result.Should().Contain(new KeyValuePair<User, int>(new User() { Id = 1, Name = "a" }, 2));
        result.Should().Contain(new KeyValuePair<User, int>(new User() { Id = 2, Name = "e" }, 2));
    }

    [Fact]
    public void CountDuplicates_UniqueObjectSequence_ReturnEmptyDic()
    {
        var result = SampleData.UniqueUsers.CountDuplicates();

        result.Count.Should().Be(0);
    }

    [Fact]
    public void CountDuplicates_SourceIsNull_ThrowArgumentNullException()
    {
        IEnumerable<int>? data = default;

        Action act = () => data.CountDuplicates();

        act.Should().Throw<ArgumentNullException>()
            .WithParameterName("source")
            .WithMessage("Value cannot be null. (Parameter 'source')");
    }

    [Fact]
    public void TotalDuplicates_SequeceWithNoDuplicates_ReturnZero()
    {
        var data = new int[] { 1, 2, 3, 4, 5, 6, 7 };

        var result = data.TotalDuplicates();

        result.Should().Be(0);
    }

    [Fact]
    public void TotalDuplicates_EmptySequence_ReturnZero()
    {
        var data = Array.Empty<int>();

        var result = data.TotalDuplicates();

        result.Should().Be(0);
    }

    [Fact]
    public void TotalDuplicates_SequeceContainDuplicates_ReturnTotalDuplicatesCount()
    {
        var data = new int[] { 1, 2, 3, 4, 2, 4, 5, 6, 7, 2, 5 };

        var result = data.TotalDuplicates();

        result.Should().Be(3);
    }

    [Fact]
    public void TotalDuplicates_DuplicateObjectSequence_ReturnTotalDuplicatesCount()
    {
        var result = SampleData.DuplicateUsers.TotalDuplicates();

        result.Should().Be(2);
    }

    [Fact]
    public void TotalDuplicates_UniqueObjectSequence_ReturnZero()
    {
        var result = SampleData.UniqueUsers.TotalDuplicates();

        result.Should().Be(0);
    }

    [Fact]
    public void TotalDuplicates_SourceIsNull_ThrowArgumentNullException()
    {
        IEnumerable<int>? data = default;

        Action act = () => data.TotalDuplicates();

        act.Should().Throw<ArgumentNullException>()
            .WithParameterName("source")
            .WithMessage("Value cannot be null. (Parameter 'source')");
    }

    [Fact]
    public void ForeEach_IntSequenceMultiplyByTwo_ReturnNewSequenceWithNewValues()
    {
        IEnumerable<int> data = new List<int> { 1, 2, 3, 4, 5, 6, 7 };

        var result = data.ForEach(n => n * 2);

        result.Count().Should().Be(7);
        data.Should().BeEquivalentTo(data);
        result.Should().BeEquivalentTo(new int[] { 2, 4, 6, 8, 10, 12, 14 });
    }

    [Fact]
    public void ForeEach_UserSequenceChangeName_ReturnNewSequenceWithUpdatedName()
    {
        IEnumerable<User> data = new List<User> { new User { Name = "a" }, new User { Name = "b" } };

        var result = data.ForEach(user =>
        {
            user.Name += " user";
            return user;
        });

        result.Count().Should().Be(2);
        data.Should().BeEquivalentTo(data);
        result.Should().BeEquivalentTo(new List<User> { new User { Name = "a user" }, new User { Name = "b user" } });
    }

    [Fact]
    public void ForeEach_FuncIsNull_ThrowArgumentNullException()
    {
        IEnumerable<int> data = new int[] { 1, 2, 3, 4 };

        Func<int, int>? func = null;

        Action act = () => data.ForEach(func).ToList();

        act.Should().Throw<ArgumentNullException>()
            .WithParameterName("func")
            .WithMessage("Value cannot be null. (Parameter 'func')");
    }

    [Fact]
    public void ForeEach_SourceIsNull_ThrowArgumentNullException()
    {
        IEnumerable<int>? data = default;

        Action act = () => data.ForEach(n => n * 2).ToList();

        act.Should().Throw<ArgumentNullException>()
            .WithParameterName("source")
            .WithMessage("Value cannot be null. (Parameter 'source')");
    }
}

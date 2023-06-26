using FluentAssertions;
using Simple.Extensions.Testing.Helpers;

namespace Simple.Extensions.Testing;
public class QueryableExtensionsTests
{
    [Fact]
    public async Task ToPaginatedListAsync_GetPageNumberZero_ReturnValidNumberOfRecords()
    {
        var result = await SampleData.GetSampleUsers(32).ToPaginatedListAsync(0, 10);

        result.Data.Count().Should().Be(10);
        result.Meta.TotalRecords.Should().Be(32);
        result.Meta.TotalPages.Should().Be(4);
        result.Meta.Next.Should().Be(true);
        result.Meta.Previous.Should().Be(false);
        result.Meta.PageIndex.Should().Be(1);
    }

    [Fact]
    public async Task ToPaginatedListAsync_GetPageNumberNegative_ReturnValidNumberOfRecords()
    {
        var result = await SampleData.GetSampleUsers(32).ToPaginatedListAsync(-1, 10);

        result.Data.Count().Should().Be(10);
        result.Meta.TotalRecords.Should().Be(32);
        result.Meta.TotalPages.Should().Be(4);
        result.Meta.Next.Should().Be(true);
        result.Meta.Previous.Should().Be(false);
        result.Meta.PageIndex.Should().Be(1);
    }

    [Fact]
    public async Task ToPaginatedListAsync_GetPageSizeZero_ReturnValidNumberOfRecords()
    {
        var result = await SampleData.GetSampleUsers(32).ToPaginatedListAsync(1, 0);

        result.Data.Count().Should().Be(10);
        result.Meta.TotalRecords.Should().Be(32);
        result.Meta.TotalPages.Should().Be(4);
        result.Meta.Next.Should().Be(true);
        result.Meta.Previous.Should().Be(false);
        result.Meta.PageIndex.Should().Be(1);
    }

    [Fact]
    public async Task ToPaginatedListAsync_GetPageSizeNegative_ReturnValidNumberOfRecords()
    {
        var result = await SampleData.GetSampleUsers(32).ToPaginatedListAsync(1, -10);

        result.Data.Count().Should().Be(10);
        result.Meta.TotalRecords.Should().Be(32);
        result.Meta.TotalPages.Should().Be(4);
        result.Meta.Next.Should().Be(true);
        result.Meta.Previous.Should().Be(false);
        result.Meta.PageIndex.Should().Be(1);
    }

    [Fact]
    public async Task ToPaginatedListAsync_GetFirstPage_ReturnValidNumberOfRecords()
    {
        var result = await SampleData.GetSampleUsers(32).ToPaginatedListAsync(1, 10);

        result.Data.Count().Should().Be(10);
        result.Meta.TotalRecords.Should().Be(32);
        result.Meta.TotalPages.Should().Be(4);
        result.Meta.Next.Should().Be(true);
        result.Meta.Previous.Should().Be(false);
        result.Meta.PageIndex.Should().Be(1);
    }

    [Fact]
    public async Task ToPaginatedListAsync_GetSecondPage_ReturnValidNumberOfRecords()
    {
        var result = await SampleData.GetSampleUsers(32).ToPaginatedListAsync(2, 10);

        result.Data.Count().Should().Be(10);
        result.Meta.TotalRecords.Should().Be(32);
        result.Meta.TotalPages.Should().Be(4);
        result.Meta.Next.Should().Be(true);
        result.Meta.Previous.Should().Be(true);
        result.Meta.PageIndex.Should().Be(2);
    }

    [Fact]
    public async Task ToPaginatedListAsync_GetThirdPage_ReturnValidNumberOfRecords()
    {
        var result = await SampleData.GetSampleUsers(32).ToPaginatedListAsync(3, 10);

        result.Data.Count().Should().Be(10);
        result.Meta.TotalRecords.Should().Be(32);
        result.Meta.TotalPages.Should().Be(4);
        result.Meta.Next.Should().Be(true);
        result.Meta.Previous.Should().Be(true);
        result.Meta.PageIndex.Should().Be(3);
    }

    [Fact]
    public async Task ToPaginatedListAsync_GetLastPage_ReturnValidNumberOfRecords()
    {
        var result = await SampleData.GetSampleUsers(32).ToPaginatedListAsync(4, 10);

        result.Data.Count().Should().Be(2);
        result.Meta.TotalRecords.Should().Be(32);
        result.Meta.TotalPages.Should().Be(4);
        result.Meta.Next.Should().Be(false);
        result.Meta.Previous.Should().Be(true);
        result.Meta.PageIndex.Should().Be(4);
    }

    [Fact]
    public void WhereIf_TrueCondition_FilterTheData()
    {
        var data = SampleData.GetSampleUsers(30);

        var result = data.WhereIf(u => u.Id % 2 == 0, () => 1 == 1).ToList();

        result.Count.Should().Be(15);
    }

    [Fact]
    public void WhereIf_FalseCondition_NoFilterApplied()
    {
        var data = SampleData.GetSampleUsers(30);

        var result = data.WhereIf(u => u.Id % 2 == 0, () => 1 == 2).ToList();

        result.Count.Should().Be(30);
    }
}

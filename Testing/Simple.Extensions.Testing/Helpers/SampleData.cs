using System.ComponentModel;

namespace Simple.Extensions.Testing.Helpers;
internal class SampleData
{
    public record Person(int Id, string Name);

    public static IQueryable<Person> GetSampleUsers(int count)
        => Enumerable.Range(0, count).Select(u => new Person(u + 1, $"User_{u + 1}")).AsQueryable();

    public enum Types
    {
        [Description("This is type A")] TypeA,
        TypeB,
        [Description("This is type C")] TypeC,
        [Description("This is type D")] TypeD,
        [Description("This is type E")] TypeE,
        [Description("This is type F")] TypeF
    }
}

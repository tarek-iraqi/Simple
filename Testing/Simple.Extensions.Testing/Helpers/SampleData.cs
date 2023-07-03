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

    public static IEnumerable<User> DuplicateUsers
        => new[]
        {
            new User() { Id = 1, Name = "a" },
            new User() { Id = 2, Name = "b" },
            new User() { Id = 1, Name = "a" },
            new User() { Id = 3, Name = "c" },
            new User() { Id = 4, Name = "d" },
            new User() { Id = 2, Name = "e" },
        };

    public static IEnumerable<User> UniqueUsers
        => new[]
        {
            new User() { Id = 1, Name = "a" },
            new User() { Id = 2, Name = "b" },
            new User() { Id = 3, Name = "c" },
            new User() { Id = 4, Name = "d" },
        };

    public static IEnumerable<User> ValidCountryAndAge
        => new[]
        {
            new User() { Id = 1, Name = "a", Country = "Egypt", DateOfBirth = new DateTime(1991, 3, 23) },
            new User() { Id = 2, Name = "b", Country = "Saudi", DateOfBirth = new DateTime(1990, 4, 12) },
            new User() { Id = 3, Name = "c", Country = "Egypt", DateOfBirth = new DateTime(1995, 5, 1) },
            new User() { Id = 4, Name = "d", Country = "Saudi", DateOfBirth = new DateTime(1999, 6, 22) },
        };

    public static IEnumerable<User> NotValidCountryAndAge
        => new[]
        {
            new User() { Id = 1, Name = "a", Country = "Egypt", DateOfBirth = new DateTime(2001, 3, 23) },
            new User() { Id = 2, Name = "b", Country = "Saudi", DateOfBirth = new DateTime(1990, 4, 12) },
            new User() { Id = 3, Name = "c", Country = "UAE", DateOfBirth = new DateTime(1995, 5, 1) },
            new User() { Id = 4, Name = "d", Country = "Saudi", DateOfBirth = new DateTime(1999, 6, 22) },
        };
}

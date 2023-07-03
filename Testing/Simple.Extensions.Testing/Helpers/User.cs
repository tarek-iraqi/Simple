namespace Simple.Extensions.Testing.Helpers;
internal class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public DateTime DateOfBirth { get; set; }

    public override bool Equals(object obj)
    {
        return obj is User q && q.Id == Id;
    }

    public override int GetHashCode()
    {
        return (GetType().ToString() + Id).GetHashCode();
    }
}

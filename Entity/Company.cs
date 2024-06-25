namespace EFWithDDD.Entity;

public class Company(long id, string name)
{
    public long Id { get; private set; } = id;
    public Guid Uuid { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; } = name;
}
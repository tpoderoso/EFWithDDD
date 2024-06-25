namespace EFWithDDD.ValuesObjects;

public class Name(string firstName, string lastName)
{
    public string FirstName { get; private set; } = firstName;
    public string LastName { get; private set; } = lastName;
    public override string ToString() => $"{FirstName} {LastName}";

}
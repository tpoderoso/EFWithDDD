namespace EFWithDDD.Entity;

public class Address(
    int id,
    Company company,
    string street,
    int number,
    Customer customer,
    int customerId)
    : BaseEntity(id, company)
{
    public string Street { get; } = street;
    public int Number { get; } = number;
    public Customer Customer { get; } = customer;
    public int CustomerId { get; } = customerId;
    
    protected Address() : this(0,
        new Company(0, ""),
        "", 0, null, 0) { }

    public override string ToString() => $"{Street} - {Number}";
}
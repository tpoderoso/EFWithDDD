namespace EFWithDDD.Entity;

public class JobFunction(int id, Company company, string title) : BaseEntity(id, company)
{
    public string Title { get; } = title;
    public IReadOnlyCollection<Customer> Customers => _customers.AsReadOnly();
    private List<Customer> _customers;
    public void AddCustomer(Customer customer) => _customers.Add(customer);

    private JobFunction() : this(0, new Company(0, ""), "") { }
}
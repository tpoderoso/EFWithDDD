using EFWithDDD.ValuesObjects;

namespace EFWithDDD.Entity;

public class Customer(int id, 
    Company company,
    Name fullName, 
    DateTime? birthdate,
    Address address) : BaseEntity(id, company)
{
    public Name FullName { get; } = fullName;
    public DateTime? Birthdate { get; } = birthdate;
    public Address Address { get; } = address;
    public IReadOnlyCollection<JobFunction> JobFunctions => _jobFunctions.AsReadOnly();
    private List<JobFunction> _jobFunctions = [];

    private Customer() : this(0,
        new Company(0, ""),
        null, null, null) { }

    public void AddJobFunction(JobFunction jobFunction) => _jobFunctions.Add(jobFunction);
    public void RemoveJobFunction(JobFunction jobFunction) => _jobFunctions.Remove(jobFunction);

    public override string ToString()
    {
        return $"Nome: {FullName.ToString()} \n" +
               $"Endereço: {Address.ToString()} \n" +
               $"Funções: \n {GetAllJobs()} \n";
    }

    private string GetAllJobs() => string.Join(Environment.NewLine, _jobFunctions.Select(j => j.Title));
}
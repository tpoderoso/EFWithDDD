using System.Runtime.InteropServices.JavaScript;

namespace EFWithDDD.Entity;

public abstract class BaseEntity(int id, Company company)
{
    public int Id { get; } = id;
    public Guid Uuid { get; private set; } = Guid.NewGuid();
    public Company Company { get; } = company;
    public long CompanyId {get; } = company.Id;
}
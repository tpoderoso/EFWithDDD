using EFWithDDD.Data.Mappings;
using EFWithDDD.Entity;
using Microsoft.EntityFrameworkCore;

namespace EFWithDDD.Data.Context;

public class ApplicationDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Address> Addresses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options) 
        => options.UseSqlServer("Server=localhost;Database=EFWithDDD;User Id=sa;Password=epilef;Encrypt=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerMap());
        modelBuilder.ApplyConfiguration(new AddressMap());
        modelBuilder.ApplyConfiguration(new JobFunctionMap());
    }
}
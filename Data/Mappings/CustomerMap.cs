using EFWithDDD.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFWithDDD.Data.Mappings;

public class CustomerMap : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customer");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.Uuid)
            .IsRequired();

        builder.Property<DateTime?>("Birthdate")
            .HasColumnName("Birthdate");

        builder.HasOne(x => x.Company)
            .WithMany()
            .HasForeignKey(x => x.CompanyId)
            .HasConstraintName("FK_Company_Customer");

        builder.HasMany(x => x.JobFunctions)
            .WithMany(x => x.Customers)
            .UsingEntity<Dictionary<string, object>>(
                "CustomerJobs",
                j => j.HasOne<JobFunction>().WithMany().HasForeignKey("FK_CustomerJobs_JobFunction").OnDelete(DeleteBehavior.Restrict),
                c => c.HasOne<Customer>().WithMany().HasForeignKey("FK_CustomerJobs_Customer").OnDelete(DeleteBehavior.Restrict)
            );

        builder.OwnsOne(x => x.FullName,
            fullName =>
            {
                fullName.Property(x => x.FirstName)
                    .HasColumnName("FirstName")
                    .HasMaxLength(200);

                fullName.Property(x => x.LastName)
                    .HasColumnName("LastName")
                    .HasMaxLength(200);
            });

        builder.HasOne(x => x.Address)
            .WithOne(x => x.Customer)
            .HasConstraintName("FK_Customer_Address");
    }
}
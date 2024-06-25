using EFWithDDD.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFWithDDD.Data.Mappings;

public class AddressMap : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Address");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.Uuid)
            .HasColumnName("Uuid")
            .IsRequired();

        builder.HasOne(x => x.Company)
            .WithMany()
            .HasForeignKey(x => x.CompanyId)
            .HasConstraintName("FK_Company_Address");

        builder.Property(x => x.Number)
            .HasColumnName("Number");

        builder.Property(x => x.Street)
            .HasColumnName("Street");

        builder.HasOne(x => x.Customer)
            .WithOne(x => x.Address)
            .HasForeignKey<Address>(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Customer_Address");
    }
}
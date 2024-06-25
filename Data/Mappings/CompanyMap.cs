using EFWithDDD.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFWithDDD.Data.Mappings;

public class CompanyMap : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Company");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.HasIndex(x => x.Uuid)
            .IsUnique();
        
        builder.Property(x => x.Uuid)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(200);
    }
}
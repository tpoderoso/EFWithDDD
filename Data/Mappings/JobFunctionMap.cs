using EFWithDDD.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFWithDDD.Data.Mappings;

public class JobFunctionMap : IEntityTypeConfiguration<JobFunction>
{
    public void Configure(EntityTypeBuilder<JobFunction> builder)
    {
        builder.ToTable("JobFunction");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.HasOne(x => x.Company)
            .WithMany()
            .HasForeignKey(x => x.CompanyId)
            .HasConstraintName("FK_Company");

        builder.Property(x => x.Uuid)
            .IsRequired();

        builder.Property(x => x.Title)
            .HasColumnName("Title")
            .HasMaxLength(200);

    }
}
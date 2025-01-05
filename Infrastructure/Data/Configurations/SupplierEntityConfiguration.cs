using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetTail.Domain.Entities;

namespace VetTail.Infrastructure.Data.Configurations;

public class SupplierEntityConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ToTable("vet_suppliers");

        builder.HasKey(s => s.Id)
            .HasName("pk-vet_suppliers-id");

        builder.Property(s => s.Id)
            .HasColumnName("_id")
            .ValueGeneratedOnAdd()
            .IsRequired();


        builder.Property(p => p.Name)
            .HasColumnName("supplier_name")
            .IsRequired();


        builder.Property(p => p.PhoneNumber)
            .HasColumnName("supplier_phone_number")
            .HasDefaultValue(null)
            .IsRequired(false);

        builder.Property(p => p.Email)
            .HasColumnName("supplier_email_address")
            .HasDefaultValue(null)
            .IsRequired(false);

        builder.Property(p => p.Address)
            .HasColumnName("supplier_address")
            .HasDefaultValue(null)
            .IsRequired(false);
    }
}

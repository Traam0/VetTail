using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetTail.Domain.Entities;
using VetTail.Domain.Enums;

namespace VetTail.Infrastructure.Data.Configurations;

internal sealed class ClientEntityConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("vet_clients");

        builder.HasKey(c => c.Id)
            .HasName("pk_vet_clients_id");

        builder.Property(c => c.Id)
            .HasColumnName("_id")
            .ValueGeneratedOnAdd();

        builder.Property(c => c.FirstName)
            .HasColumnName("first_name")
            .IsRequired();

        builder.Property(c => c.LastName)
            .HasColumnName("last_name")
            .IsRequired();

        builder.Property(c => c.Image)
            .HasColumnName("image")
            .IsRequired(false)
            .HasDefaultValue(null);

        builder.Property(c => c.CIN)
            .HasColumnName("cin")
            .IsRequired();

         builder.Property(c => c.PreferredContactMethod)
            .HasColumnName("preferred_contact_method")
            .IsRequired()
            .HasDefaultValue(ContactMethod.Phone);

        builder.Property(c => c.Phone)
            .HasColumnName("phone_number")
            .IsRequired(false)
            .HasDefaultValue(null);

        builder.Property(c => c.Email)
            .HasColumnName("email_address")
            .IsRequired(false)
            .HasDefaultValue(null);

        builder.Property(c => c.Address)
            .HasColumnName("address")
            .IsRequired(false)
            .HasDefaultValue(null);

        builder.Property(c => c.City)
            .HasColumnName("city")
            .IsRequired(false)
            .HasDefaultValue(null);


        builder.HasIndex(c => c.CIN, "unique_vet_clients_cin").IsUnique();
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetTail.Domain.Entities;
using VetTail.Domain.Enums;

namespace VetTail.Infrastructure.Data.Configurations;

public sealed class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("vet_users");

        builder.HasKey(t => t.Id)
            .HasName("pk_vet_users_id");

        builder.Property(u => u.Id)
            .HasColumnName("_id")
            .ValueGeneratedOnAdd();

        builder.Property(u => u.FirstName)
            .HasColumnName("first_name")
            .IsRequired();

        builder.Property(u => u.LastName)
            .HasColumnName("last_name")
            .IsRequired();

        builder.Property(u => u.CIN)
            .HasColumnName("cin")
            .IsRequired();

        builder.Property(u => u.Phone)
            .HasColumnName("phone_number")
            .IsRequired();

        builder.Property(u => u.Gender)
            .HasColumnName("gender")
            .IsRequired()
            .HasDefaultValue(Gender.Unknown);

        builder.Property(u => u.Username)
            .HasColumnName("username")
            .IsRequired();

        builder.Property(u => u.Password)
            .HasColumnName("password")
            .IsRequired();

        builder.Property(u => u.Role)
            .HasColumnName("role")
            .IsRequired()
            .HasDefaultValue(Role.Staff);

        builder.Property(u => u.Status)
            .HasColumnName("account_status")
            .IsRequired()
            .HasDefaultValue(AccountStatus.Active);

        builder.Property(u => u.Email)
            .HasColumnName("email_address")
            .IsRequired(false)
            .HasDefaultValue(null);

        builder.Property(u => u.Image)
            .HasColumnName("image")
            .IsRequired(false)
            .HasDefaultValue(null);

        builder.Property(u => u.DateOfBirth)
            .HasColumnName("date_of_birth")
            .IsRequired();

        builder.Property(u => u.Hash)
            .HasColumnName("sec_hash")
            .HasComment("security hash to keep track of row version and invalidate sessions")
            .IsRequired(false)
            .HasDefaultValue(null);


        builder.Property(u => u.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(u => u.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired(false);


        builder.HasIndex(u => u.CIN, "unique_vet_users_cin").IsUnique();
        builder.HasIndex(u => u.Username, "unique_vet_users_username").IsUnique();
        builder.HasIndex(u => u.Email, "unique_vet_users_email_address").IsUnique();
        builder.HasIndex(u => u.Phone, "unique_vet_users_phone_number");
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetTail.Domain.Entities;
using VetTail.Domain.Enums;

namespace VetTail.Infrastructure.Data.Configurations;

internal sealed class UsersConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("vet_users");
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .HasColumnName("_id")
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(u => u.Email)
            .HasColumnName("email")
            .IsRequired();

        builder.Property(u => u.Username)
            .HasColumnName("username")
            .IsRequired();

        builder.Property(u => u.Password)
            .HasColumnName("password")
            .IsRequired();

        builder.Property(u => u.Role)
            .HasColumnName("user_role")
            .IsRequired()
            .HasDefaultValue(Role.StaffMember);

        builder.Property(u => u.CIN)
            .HasColumnName("cin")
            .IsRequired();

        builder.Property(u => u.FirstName)
            .HasColumnName("first_name")
            .IsRequired();

        builder.Property(u => u.LastName)
            .HasColumnName("last_name")
            .IsRequired();

        builder.Property(u => u.Phone)
            .HasColumnName("phone_number")
            .IsRequired(false);

        builder.Property(u => u.Image)
            .HasColumnName("image")
            .IsRequired(false);

        builder.HasIndex(u => u.Id, "pk_vet_users_id").IsUnique();
        builder.HasIndex(u => u.Email, "unique_vet_users_email").IsUnique();
        builder.HasIndex(u => u.Username, "unique_vet_users_username").IsUnique();
        builder.HasIndex(u => u.CIN, "unique_vet_users_cin").IsUnique();
        builder.HasIndex(u => u.Phone, "unique_vet_users_phone_number").IsUnique();
    }
}


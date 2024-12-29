using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using VetTail.Domain.Entities;
using VetTail.Domain.Enums;

namespace VetTail.Infrastructure.Data.Configurations;

public sealed class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("vet_users");

        builder.HasKey(t => t.Id)
            .HasName("pk-vet_users-id");


        builder.Property(u => u.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(u => u.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired(false);


        //builder.HasIndex(u => u.CIN, "unique_vet_users_cin").IsUnique();
        builder.HasIndex(u => u.UserName, "unique-vet_users_username").IsUnique();
        builder.HasIndex(u => u.Email, "unique-vet_users_email_address").IsUnique();
    }
}

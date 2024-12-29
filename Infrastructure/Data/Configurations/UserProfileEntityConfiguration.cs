using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetTail.Domain.Entities;
using VetTail.Domain.Enums;

namespace VetTail.Infrastructure.Data.Configurations;

public class UserProfileEntityConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.ToTable("vet_user_profiles");

        builder.HasKey(t => t.UserId)
            .HasName("pk-vet_user_profile-user_id");


        builder.Property(u => u.UserId)
           .HasColumnName("_id");

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

        builder.Property(u => u.Image)
            .HasColumnName("image")
            .IsRequired(false)
            .HasDefaultValue(null);

        builder.Property(u => u.DateOfBirth)
            .HasColumnName("date_of_birth")
            .IsRequired();

        builder.HasOne(p => p.User)
                    .WithOne()
                    .HasForeignKey<UserProfile>(p => p.UserId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk-vet_users-vet_user_profliles-user_id");

        builder.HasIndex(u => u.CIN, "unique-vet_users_cin").IsUnique();

    }
}

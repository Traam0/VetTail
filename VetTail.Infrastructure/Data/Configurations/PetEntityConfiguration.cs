using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using VetTail.Domain.Entities;
using VetTail.Domain.Enums;

namespace VetTail.Infrastructure.Data.Configurations;

internal sealed class PetEntityConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("vet_pets");

        builder.HasKey(p => p.Id)
            .HasName("pk_vet_pets_id");

        builder.Property(p => p.Id)
            .HasColumnName("_id")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Name)
            .HasColumnName("name")
            .IsRequired();

        builder.Property(p => p.Weight)
            .HasColumnName("weight");

        builder.Property(p => p.Gender)
            .HasColumnName("gender")
            .IsRequired()
            .HasDefaultValue(Gender.Male);

        builder.Property(p => p.Status)
            .HasColumnName("status")
            .IsRequired()
            .HasDefaultValue(PetStatus.Active);

        builder.Property(p => p.Species)
            .HasColumnName("pet_species")
            .IsRequired();

        builder.Property(p => p.Breed)
            .HasColumnName("pet_breed")
            .IsRequired(false)
            .HasDefaultValue(null);

        builder.Property(p => p.MicroChipId)
            .HasColumnName("microchip_id")
            .IsRequired();

        builder.Property(p => p.Color)
            .HasColumnName("color")
            .IsRequired(false)
            .HasDefaultValue(null);

        builder.Property(p => p.DateRegistered)
            .HasColumnName("registery_date")
            .IsRequired()
            .HasDefaultValue(DateOnly.FromDateTime(DateTime.Today));

        builder.Property(p => p.DateOfBirth)
            .HasColumnName("birth_date")
            .IsRequired(false)
            .HasDefaultValue(null);

        builder.Property(p => p.CreatedAt)
         .HasColumnName("created_at")
         .IsRequired();

        builder.Property(p => p.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired(false);

        builder.Property(p => p.OwnerId)
            .HasColumnName("owner_id")
            .IsRequired();

        builder.HasOne(p => p.Owner)
            .WithMany(o => o.Pets)
            .HasForeignKey(p => p.OwnerId)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("fk_vet_pets_vet_clients_client_id")
            .IsRequired();

        builder.HasIndex(p => p.MicroChipId, "unique_vet_pets_micorchip_id").IsUnique();
    }
}

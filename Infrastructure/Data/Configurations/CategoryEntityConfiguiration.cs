using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetTail.Domain.Entities;

namespace VetTail.Infrastructure.Data.Configurations;

public class CategoryEntityConfiguiration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("vet_categories");

        builder.HasKey(c => c.Id)
            .HasName("pk-vet_categories-id");

        builder.Property(c => c.Id)
            .HasColumnName("_id")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(c => c.Name)
            .HasColumnName("category_name")
            .IsRequired();

        builder.Property(c => c.Description)
            .HasColumnName("category_description")
            .HasDefaultValue(null)
            .IsRequired(false);
    }
}

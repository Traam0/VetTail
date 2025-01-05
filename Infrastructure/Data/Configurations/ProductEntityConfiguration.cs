using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using VetTail.Domain.Entities;

namespace VetTail.Infrastructure.Data.Configurations;

public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("vet_products");

        builder.HasKey(p => p.Id)
            .HasName("pk-vet_products-id");

        builder.Property(p => p.Id)
            .HasColumnName("_id")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(p => p.Name)
            .HasColumnName("product_name")
            .IsRequired();

        builder.Property(p => p.Description)
            .HasColumnName("product_description")
            .HasDefaultValue(null)
            .IsRequired(false);

        builder.Property(p => p.Stock)
            .HasColumnName("stock")
            .IsRequired();

        builder.Property(p => p.Price)
            .HasColumnName("unit_price")
            .HasColumnType("DECIMAL(10,2)")
            .IsRequired();

        builder.Property(p => p.ExpiryDate)
            .HasColumnName("expiry_date")
            .HasDefaultValue(null)
            .IsRequired(false);

  

        builder.Property(u => u.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(u => u.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired(false);

        builder.HasMany(p => p.Categories)
            .WithMany(c => c.Products)
            .UsingEntity(pc => pc.ToTable("vet_products_categories"));

        builder.HasMany(p => p.StockMovements)
            .WithOne(sm => sm.Product)
            .HasForeignKey(sm => sm.ProductId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("fk-vet_products-vet-stock_movments-product_id");

        builder.HasMany(p => p.Suppliers)
            .WithMany(s => s.Products)
            .UsingEntity(ps => ps.ToTable("vet_products-suppliers"));
    }
}

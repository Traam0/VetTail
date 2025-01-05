using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetTail.Domain.Entities;
using VetTail.Domain.Enums;
using VetTail.Infrastructure.Common.Converters;

namespace VetTail.Infrastructure.Data.Configurations;

public class StockMovementEntityConfiguration : IEntityTypeConfiguration<StockMovement>
{
    public void Configure(EntityTypeBuilder<StockMovement> builder)
    {
        builder.ToTable("vet_stock_movements");

        builder.HasKey(sm => sm.Id)
            .HasName("pk-vet_stock_movements-id");

        builder.Property(sm => sm.Id)
            .HasColumnName("_id")
            .ValueGeneratedOnAdd()
            .IsRequired(true);

        builder.Property(sm => sm.MovementType)
            .HasColumnName("movement_type")
            .HasDefaultValue(MovementType.ADD)
            .HasConversion(new MovementTypeConvertor())
            .IsRequired(true);

        builder.Property(sm => sm.Reason)
            .HasColumnName("movement_reason")
            .HasDefaultValue(null)
            .IsRequired(false);

        builder.Property(sm => sm.Quantity)
            .HasColumnName("quantity")
            .IsRequired();

        builder.Property(sm => sm.MovementTimeStamp)
            .HasColumnName("movement_time")
            .IsRequired();

        builder.HasOne(sm => sm.Supplier)
            .WithMany(s => s.StockMovements)
            .HasForeignKey(sm => sm.SupplierId)
            .HasConstraintName("fk-stock_movements-vet_suppliers-supplier_id");
    }
}

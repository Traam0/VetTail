using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetTail.Domain.Entities;
using VetTail.Domain.Enums;

namespace VetTail.Infrastructure.Data.Configurations;

internal sealed class ClientNotesEntityConfiguration : IEntityTypeConfiguration<ClientNotes>
{
    public void Configure(EntityTypeBuilder<ClientNotes> builder)
    {
        builder.ToTable("vet_client_notes");
        
        builder.HasKey(cn => cn.Id)
            .HasName("pk_vet_client_notes_id");

        builder.Property(cn => cn.Id)
            .HasColumnName("_id")
            .IsRequired();

        builder.Property(cn => cn.Content)
            .HasColumnName("note")
            .IsRequired();

        builder.Property(cn => cn.Priority)
            .HasColumnName("priority")
            .IsRequired()
            .HasDefaultValue(NotePriority.Low);


        builder.Property(cn => cn.CreatedAt)
             .HasColumnName("created_at")
             .IsRequired();

        builder.Property(cn => cn.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired(false);


        builder.Property(cn => cn.ClientId)
            .HasColumnName("client_id")
            .IsRequired();

        builder.HasOne(cn => cn.Client)
            .WithMany(c => c.Notes)
            .HasForeignKey(cn => cn.ClientId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("fk_vet_client_notes_vet_clients_client_id");
    }
}

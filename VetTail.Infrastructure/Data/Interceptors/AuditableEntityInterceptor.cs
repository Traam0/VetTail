using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using VetTail.Domain.Common.Abstractions;
using VetTail.Infrastructure.Extentions;

namespace VetTail.Infrastructure.Data.Interceptors;

public class AuditableEntityInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        this.UpdateEntities(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        this.UpdateEntities(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    void UpdateEntities(DbContext? context)
    {
        if (context == null) return;
        Span<EntityEntry<AuditableEntity>> entries = CollectionsMarshal.AsSpan(context.ChangeTracker.Entries<AuditableEntity>().ToList());
        if(entries.Length == 0) return;


        for(int i = 0; i < entries.Length; i++) { 
            EntityEntry<AuditableEntity> entry = entries[i];
            if (entry.State is EntityState.Added or EntityState.Modified || entry.HasUpdatedOwnedEntities())
            {
                DateTimeOffset utcNow = DateTimeOffset.UtcNow;
                if (entry.State is EntityState.Added) entry.Entity.CreatedAt = utcNow;
                if (entry.State is EntityState.Modified) entry.Entity.UpdatedAt = utcNow;
            }

        }
    }
}

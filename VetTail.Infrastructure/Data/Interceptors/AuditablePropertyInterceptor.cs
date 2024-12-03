using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using VetTail.Domain.Common.Abstractions;

namespace VetTail.Infrastructure.Data.Interceptors;

public class AuditablePropertyInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        this.InterceptEntities(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        this.InterceptEntities(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    void InterceptEntities(DbContext? context) {
        if (context is null) return;
        Span<EntityEntry<AuditableEntity>> entries = CollectionsMarshal.AsSpan(context.ChangeTracker.Entries<AuditableEntity>().ToList());

        for (int i = 0; i < entries.Length; i++)
        {
            EntityEntry<AuditableEntity> entry = entries[i];
            
            if(entry.State is EntityState.Added or EntityState.Modified)
            {
                DateTimeOffset currentTime = DateTimeOffset.UtcNow;
                if (entry.State is EntityState.Added)
                {
                    entry.Entity.CreatedAt = currentTime;
                }
                
                entry.Entity.UpdatedAt = currentTime;
            }
        }

    }
}

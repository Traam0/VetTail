using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Runtime.InteropServices;
using System;
using System.Threading;
using System.Threading.Tasks;
using VetTail.Domain.Common.Abstractions;
using VetTail.Infrastructure.Extentions;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace VetTail.Infrastructure.Data.Interceptors;

public sealed class AuditableEntityInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    void UpdateEntities(DbContext? context)
    {
        if (context == null) return;
        Span<EntityEntry<AuditableEntity>> entries = CollectionsMarshal.AsSpan(context.ChangeTracker.Entries<AuditableEntity>()?.ToList());
        if (entries.Length == 0) return;

        for (int i = 0; i < entries.Length; i++)
        {
            EntityEntry<AuditableEntity> entry = entries[i];
            if (entry.State is EntityState.Added or EntityState.Modified || entry.HasUpdatedOwnedEntities())
            {
                DateTimeOffset utcNow = DateTimeOffset.UtcNow;
                if (entry.State is EntityState.Added) entry.Entity.CreatedAt = utcNow;
                if (entry.State is EntityState.Modified)
                {
                    if (entry.Entity.TryGetSecurityHash(out string? securityHash))
                    {
                        entry.Entity.GetType()
                            .GetProperties()
                            .FirstOrDefault(p => p.Name == "Hash")
                            ?.SetValue(entry.Entity, securityHash);
                    }

                    entry.Entity.UpdatedAt = utcNow;
                }
            }

        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;

namespace VetTail.Infrastructure.Extentions;
internal static class EntityEntryExtentions
{
    public static bool HasUpdatedOwnedEntities(this EntityEntry entry)
    {
        return entry.References.Any(r => r.TargetEntry is not null &&
            r.TargetEntry.Metadata.IsOwned() &&
            r.TargetEntry.State is EntityState.Added or EntityState.Modified
        );
    }
}
using MediatR;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using VetTail.Domain.Common.Abstractions;
using System.Linq;

namespace VetTail.Infrastructure.Data.Interceptors;

public class EventsDispatcherInterceptor(IMediator mediator) : SaveChangesInterceptor
{
    private readonly IMediator mediator = mediator;

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        DispatchEvents(eventData.Context).GetAwaiter().GetResult();

        return base.SavingChanges(eventData, result);
    }

    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        await DispatchEvents(eventData.Context);

        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public async Task DispatchEvents(DbContext? context)
    {
        if (context is null) return;

        IEnumerable<Entity> entities = context.ChangeTracker.Entries<Entity>()
            .Where(x => x.Entity.Events.Any())
            .Select(x => x.Entity);


        IEnumerable<Event> events = entities.SelectMany(x => x.Events);

        foreach (Event @event in events) {
            await mediator.Publish(@event);
        }
        
        entities.ToList().ForEach(x => x.ClearEvents());
    }
}

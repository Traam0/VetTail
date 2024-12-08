using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VetTail.Domain.Common.Abstractions;

namespace VetTail.Infrastructure.Data.Interceptors;

public class EventDispatcherInterceptor : SaveChangesInterceptor
{
    private readonly IMediator mediator;

    public EventDispatcherInterceptor(IMediator mediator)
    {
        this.mediator = mediator;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        this.DispatchEvents();
        return base.SavingChanges(eventData, result);
    }

    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        await this.DispatchEvents(eventData.Context);
        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }


    public async Task DispatchEvents(DbContext? context)
    {
        if (context is null) return;

        IEnumerable<Entity> entities = context.ChangeTracker.Entries<Entity>()
            .Where(entry => entry.Entity.Events.Any())
            .Select(entry => entry.Entity);

        IEnumerable<Event> events = entities.SelectMany(e => e.Events);

        foreach (Event @event in events)
        {
            await this.mediator.Publish(@event);
        }

        foreach (Entity entity in entities)
        {
            entity.UnregisterAll();
        }

    }
}

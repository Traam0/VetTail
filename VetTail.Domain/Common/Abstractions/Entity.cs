using System.Collections.Generic;

namespace VetTail.Domain.Common.Abstractions;

public abstract class Entity
{
    private readonly List<Event> events = [];
    public IReadOnlyCollection<Event> Events => events;

    public Entity RegisterEvent(Event @event)
    {
        this.events.Add(@event);
        return this;
    }

    public Entity UnregisterEvent(Event @event)
    {
        this.events.Remove(@event);
        return this;
    }

    public Entity UnregisterAll() { 
        this.events.Clear();
        return this;
    }
}

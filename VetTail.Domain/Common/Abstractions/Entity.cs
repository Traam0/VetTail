using System.Collections.Generic;

namespace VetTail.Domain.Common.Abstractions;

public abstract class Entity
{
    private readonly List<Event> _events = [];
    public IReadOnlyCollection<Event> Events => _events.AsReadOnly();

    public void RegisterEvent(Event @event)
    {
        _events.Add(@event);
    }

    public void UnregisterEvent(Event @event) { 
        _events.Remove(@event);
    }

    public void ClearEvents()
    {
        _events.Clear();
    }
}

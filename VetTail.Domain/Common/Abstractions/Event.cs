using System;

namespace VetTail.Domain.Common.Abstractions;

public abstract class Event
{
    public string Id { get; } = Guid.NewGuid().ToString("X");
}

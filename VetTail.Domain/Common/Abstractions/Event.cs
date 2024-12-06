using MediatR;
using System;

namespace VetTail.Domain.Common.Abstractions;

public abstract class Event : INotification
{
    public string EventId { get; set; } = Guid.NewGuid().ToString("X");
}

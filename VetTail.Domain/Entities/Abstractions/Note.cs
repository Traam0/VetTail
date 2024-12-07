using System;
using VetTail.Domain.Common.Abstractions;
using VetTail.Domain.Enums;

namespace VetTail.Domain.Entities.Abstractions;

public abstract class Note : AuditableEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Content { get; set; }
    public NotePriority Priority { get; set; }
}

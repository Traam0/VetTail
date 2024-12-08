using System;
using System.Collections.Generic;
using VetTail.Domain.Common.Abstractions;
using VetTail.Domain.Enums;

namespace VetTail.Domain.Entities;

public  class Pet : AuditableEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString("X");

    public required string Name { get; set; }
    public double Weight { get; set; }
    public Gender Gender { get; set; }
    public PetStatus Status { get; set; }

    public required string Species { get; set; }
    public string? Breed { get; set; }
    public string? MicroChipId { get; set; }
    public string? Color { get; set; }

    public DateOnly? DateRegistered { get; set; }
    public DateTimeOffset DateOfBirth { get; set; }

    public ulong OwnerId { get; set; } 
    public Client Owner { get; set; }
    public ICollection<PetNotes> Notes { get; set; }

}

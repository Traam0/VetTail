using VetTail.Domain.Common.Attributes;
using VetTail.Domain.Common.Abstractions;
using VetTail.Domain.Enums;
using System;

namespace VetTail.Domain.Entities;

public class User : AuditableEntity
{
    public ulong Id { get; set; }

    [AuditableProperty] public required string Email { get; set; }
    [AuditableProperty] public required string Username { get; set; }
    [AuditableProperty] public required string Password { get; set; }
    [AuditableProperty] public Role Role { get; set; }
    [AuditableProperty] public required string CIN { get; set; }
    public Gender Gender { get; set; }

    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    public string? Phone { get; set; }
    public string? Image { get; set; }
    public DateOnly Birthdate { get; set; }
    
    [AuditableProperty] public new DateTimeOffset UpdatedAt { get; set; }
}
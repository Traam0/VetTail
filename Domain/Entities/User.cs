using System;
using VetTail.Domain.Common.Abstractions;
using VetTail.Domain.Common.Attributes;
using VetTail.Domain.Enums;

namespace VetTail.Domain.Entities;

public sealed class User : AuditableEntity
{
    public ulong Id { get; set; }

    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    [AuditableProperty] public required string CIN { get; set; }
    public required string Phone { get; set; }
    public Gender Gender { get; set; }

    [AuditableProperty] public required string Username { get; set; }
    [AuditableProperty] public required string Password { get; set; }
    [AuditableProperty] public Role Role { get; set; }
    [AuditableProperty] public AccountStatus Status { get; set; }

    public string? Hash { get; set; }

    public string? Email { get; set; }
    public string? Image { get; set; }

    public DateOnly DateOfBirth { get; set; }
    [AuditableProperty] public new DateTimeOffset? UpdatedAt { get; set; }
}

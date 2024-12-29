using System;
using VetTail.Domain.Enums;

namespace VetTail.Domain.Entities;

public class UserProfile
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string CIN { get; set; }
    public required string Phone { get; set; }
    public Gender Gender { get; set; }
    public string? Address { get; set; }
    public string? Image { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public ulong UserId {  get; set; }
    public required User User { get; set; }
}

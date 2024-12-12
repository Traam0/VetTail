using System;

namespace VetTail.Domain.Enums;

[Flags]
public enum Role
{
    Staff = 1,
    Veterinarian = Staff << 1,
    Admin = Staff<< 2,
}

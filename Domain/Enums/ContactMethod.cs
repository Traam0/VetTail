using System;

namespace VetTail.Domain.Enums;

[Flags]
public enum ContactMethod
{
    None,
    Phone,
    Email = Phone << 1,
    Mail = Email << 1,
    Any = Mail << 1
}


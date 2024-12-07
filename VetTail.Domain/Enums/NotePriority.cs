using System;

namespace VetTail.Domain.Enums;

[Flags]
public enum NotePriority
{
    Low = 1,
    High = Low << 1,
    Critical = High << 1
}

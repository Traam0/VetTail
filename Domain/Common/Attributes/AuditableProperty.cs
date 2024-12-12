using System;

namespace VetTail.Domain.Common.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public sealed class AuditableProperty : Attribute
{
    public string? AltName { get; init; }

    public AuditableProperty(string? altName = null)
    {
        AltName = altName;
    }
}

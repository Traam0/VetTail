using System;

namespace VetTail.Domain.Common.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class AuditableProperty : Attribute
{
    public string? AltName { get; init; }

    public AuditableProperty(string? altName = null)
    {
        this.AltName = altName;
    }
}

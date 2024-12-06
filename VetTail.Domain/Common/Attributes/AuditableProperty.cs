using System;

namespace VetTail.Domain.Common.Attribues;

[AttributeUsage(AttributeTargets.Property)]
internal class AuditableProperty : Attribute
{
    public string? AltName { get; set; }

    public AuditableProperty()
    {
        this.AltName = null;
    }

    public AuditableProperty(string altName)
    {
        this.AltName = altName;
    }
}

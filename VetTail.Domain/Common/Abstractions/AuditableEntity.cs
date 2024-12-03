using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using VetTail.Domain.Common.Attributes;

namespace VetTail.Domain.Common.Abstractions;

public abstract class AuditableEntity : Entity
{
    public DateTimeOffset CreatedAt { get; set; } = DateTime.Now;
    public virtual DateTimeOffset UpdatedAt { get; set; }

    public byte[]? Hash => this.CalculateSecHash();

    protected virtual byte[]? CalculateSecHash()
    {
        IEnumerable<PropertyInfo> properties = this.GetType()
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(property => property.IsDefined(typeof(AuditableProperty), true));
    
        if(properties.Any())
        {
            //throw new NotSupportedException($"{this.GetType().Name} doesn't contain any Auditable Properties");
            return null;
        }

        StringBuilder hashBuilder = new();

        foreach (PropertyInfo property in properties) {
            string? altName = property.GetCustomAttribute<AuditableProperty>()?.AltName;
            hashBuilder.Append(string.IsNullOrEmpty(altName) ? property.Name : altName).Append(">>");
            hashBuilder.Append(property.GetValue(this)).AppendLine(">>>");
        }

        return SHA256.HashData(Encoding.UTF8.GetBytes(hashBuilder.ToString()));
    }
    
}

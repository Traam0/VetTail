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
    public DateTime CreatedAt { get; } = DateTime.Now;
    [AuditableProperty] public virtual DateTime UpdatedAt { get; set; }

    protected virtual byte[] Hash()
    {
        IEnumerable<PropertyInfo> properties = this.GetType()
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(property => property.IsDefined(typeof(AuditableProperty), true));
    
        if(properties.Any())
        {
            throw new NotSupportedException($"{this.GetType().Name} doesn't contain any Auditable Properties");
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

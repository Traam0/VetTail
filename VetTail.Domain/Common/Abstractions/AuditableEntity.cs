using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using VetTail.Domain.Common.Attribues;

namespace VetTail.Domain.Common.Abstractions;

public abstract class AuditableEntity : Entity
{
    public DateTimeOffset CreatedAt { get; set; }
    public virtual DateTimeOffset? UpdatedAt{ get; set; }

    public byte[]? Hash => null;

    protected byte[]? CalculateHash()
    {
        Span<PropertyInfo> properties = CollectionsMarshal.AsSpan(
            this.GetType()
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.IsDefined(typeof(AuditableProperty))).ToList()
        );

        if(properties.Length == 0) return null;

        StringBuilder metaData = new ();

        foreach(PropertyInfo property in properties)
        {
            string propertyName = property.GetCustomAttribute<AuditableProperty>()?.AltName ?? property.Name;
            metaData.Append(propertyName)
                .Append(">>")
                .Append(property.GetValue(this))
                .AppendLine(">>>");
        }

        StringBuilder randoed = new();

        byte[] bytes = Encoding.UTF8.GetBytes(metaData.ToString());

        for (int i = 0; i < bytes.Length; i++)
        {
            byte @byte = bytes[i];
            int n, n1, n2;
            n1 = n & 15;
            n2  = (n >> 4) & 15;
            if (n2 > 9) randoed.Append(n2 - 10 + 'A');
            else randoed.Append(n2);
            if(n1 > 9) randoed.Append(n1 - 10 + 'A');
            else randoed.Append(n1);
            if((i+1) != bytes.Length && (i+1) % 2 == 0) randoed.Append('-');
        }

        return Encoding.UTF8.GetBytes(randoed.ToString());
    }
}

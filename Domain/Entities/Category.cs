using System.Collections.Generic;

namespace VetTail.Domain.Entities;

public class Category
{
    public ulong Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }

    public ICollection<Product>? Products { get; set; }
}

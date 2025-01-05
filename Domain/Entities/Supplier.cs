using System;
using System.Collections.Generic;
using VetTail.Domain.Common.Abstractions;

namespace VetTail.Domain.Entities;

public class Supplier : AuditableEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public string? PhoneNumber { get; set; }
    public string? Email {  get; set; }
    public string? Address { get; set; }

    public ICollection<Product>? Products { get; set; }
    public ICollection<StockMovement>? StockMovements { get; set; }
}

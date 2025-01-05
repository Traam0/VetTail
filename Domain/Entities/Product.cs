using System;
using System.Collections.Generic;
using VetTail.Domain.Common.Abstractions;

namespace VetTail.Domain.Entities;

public class Product : AuditableEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public uint Stock {  get; set; }
    public decimal Price { get; set; }
    public DateOnly? ExpiryDate { get; set; } 


    public ICollection<Supplier>? Suppliers { get; set; }

    public ICollection<StockMovement>? StockMovements { get; set; }
    public ICollection<Category>? Categories { get; set; }
}

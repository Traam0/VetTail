using System;
using VetTail.Domain.Enums;

namespace VetTail.Domain.Entities;
public class StockMovement
{
    public ulong Id { get; set; }
    public MovementType MovementType { get; set; }
    public string? Reason { get; set; }
    public uint Quantity { get; set; }
    public DateTime MovementTimeStamp { get; set; }
    
    public Guid? SupplierId { get; set; }
    public Supplier? Supplier { get; set; }
    
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
}

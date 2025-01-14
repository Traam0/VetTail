using System;

namespace VetTail.Application.Common.DTOs;

public class ProductBrief
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public uint Stock { get; set; }
    public decimal Price { get; set; }
    public DateOnly? ExpiryDate { get; set; }
}

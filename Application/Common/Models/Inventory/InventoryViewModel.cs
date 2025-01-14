using System.Collections.Generic;
using VetTail.Application.Common.DTOs.Generic;
using VetTail.Application.Common.DTOs;

namespace VetTail.Application.Common.Models.Inventory;

public class InventoryViewModel
{
    public PaginatedList<ProductBrief> Products { get; set; }
    public IEnumerable<CategoryBrief> Categories { get; set; }
}

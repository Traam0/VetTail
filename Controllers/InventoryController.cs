using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VetTail.Application.Common.DTOs.Generic;
using VetTail.Application.Common.DTOs;
using VetTail.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using VetTail.Application.Common.Models.Inventory;

namespace VetTail.Controllers;

public class InventoryController : Controller
{
    private readonly IProductsService productService;
    private readonly ICategoryService categoryService;

    public InventoryController(IProductsService productService, ICategoryService categoryService)
    {
        this.productService = productService;
        this.categoryService = categoryService;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        PaginatedList<ProductBrief> products = await this.productService.GetProductsByPageAsync(pageNumber, pageSize, cancellationToken);
        IEnumerable<CategoryBrief> categories = await this.categoryService.All(cancellationToken);

        InventoryViewModel viewModel = new()
        {
            Products = products,
            Categories = categories
        };
        return View(viewModel);
    }
}

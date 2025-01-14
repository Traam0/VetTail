using System.Threading;
using System.Threading.Tasks;
using VetTail.Application.Common.DTOs;
using VetTail.Application.Common.DTOs.Generic;

namespace VetTail.Application.Common.Interfaces;

public interface IProductsService
{
    Task<PaginatedList<ProductBrief>> GetProductsByPageAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);
}

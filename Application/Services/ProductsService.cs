using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VetTail.Application.Common.DTOs;
using VetTail.Application.Common.DTOs.Generic;
using VetTail.Application.Common.Interfaces;
using VetTail.Domain.Common.Interfaces;
using VetTail.Domain.Entities;

namespace VetTail.Application.Services;

public class ProductsService : IProductsService
{
    private readonly IRepository<Product, Guid> repository;
    private readonly IMapper mapper;

    public ProductsService(IRepository<Product, Guid> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<PaginatedList<ProductBrief>> GetProductsByPageAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
    {
        IEnumerable<Product> products = await this.repository.GetAllAsync(cancellationToken);
        return PaginatedList<ProductBrief>.Create(products.Select(this.mapper.Map<ProductBrief>), pageNumber, pageSize);
    }
}

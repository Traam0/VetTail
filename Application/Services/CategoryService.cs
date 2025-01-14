using AutoMapper;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VetTail.Application.Common.DTOs;
using VetTail.Application.Common.Interfaces;
using VetTail.Domain.Common.Interfaces;
using VetTail.Domain.Entities;

namespace VetTail.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly IRepository<Category, ulong> repository;
    private readonly IMapper mapper;

    public CategoryService(IRepository<Category, ulong> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<CategoryBrief>> All(CancellationToken cancellationToken = default)
    {
        IEnumerable<Category> categories = await this.repository.GetAllAsync(cancellationToken);

        return this.mapper.Map<IEnumerable<CategoryBrief>>(categories);
    }
}

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VetTail.Application.Common.DTOs;

namespace VetTail.Application.Common.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryBrief>> All(CancellationToken cancellationToken = default);
}

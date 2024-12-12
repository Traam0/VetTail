using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using VetTail.Domain.Common.Abstractions;

namespace VetTail.Domain.Common.Interfaces;

public interface IRepository<TEntity, in TKey> where TEntity : AuditableEntity where TKey : notnull
{
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<TEntity>> GetAllAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);
    Task<TEntity?> FindByIdAsync(TKey id, CancellationToken cancellationToken = default);
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
}

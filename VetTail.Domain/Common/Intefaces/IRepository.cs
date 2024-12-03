using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VetTail.Domain.Common.Abstractions;

namespace VetTail.Domain.Common.Intefaces;

public interface IRepository<TEntity, in TKey> where TEntity : Entity where TKey : notnull
{
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellation = default);
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellation = default);
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancel = default);
    Task<TEntity> DeleteAsync(TEntity entity,CancellationToken cancellationToken = default);
}

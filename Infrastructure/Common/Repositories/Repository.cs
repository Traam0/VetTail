using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using VetTail.Domain.Common.Interfaces;
using VetTail.Infrastructure.Data.Persistance;
using VetTail.Domain.Common.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace VetTail.Infrastructure.Common.Repositories;


public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : AuditableEntity where TKey : notnull
{
    private readonly ApplicationDbContext context;

    public Repository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await this.context.Set<TEntity>()
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
    {
        return await this.context.Set<TEntity>()
            .AsNoTracking()
            .Skip(pageNumber * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }
    public async Task<TEntity?> FindByIdAsync(TKey id, CancellationToken cancellationToken = default)
    {
        return await this.context.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        EntityEntry<TEntity> entry = await this.context.Set<TEntity>().AddAsync(entity, cancellationToken);
        return entry.Entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return await Task.Run(() =>
        {
            EntityEntry<TEntity> entry = this.context.Set<TEntity>().Update(entity);
            return entry.Entity;
        }, cancellationToken);
    }

    public async Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return await Task.Run(() =>
        {
            EntityEntry<TEntity> entry = this.context.Set<TEntity>().Remove(entity);
            return entry.Entity;
        }, cancellationToken);
    }

}


using System.Threading.Tasks;
using System.Threading;
using VetTail.Domain.Common.Interfaces;
using VetTail.Infrastructure.Data.Persistance;

namespace VetTail.Infrastructure.Common.Repositories;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext context;

    public UnitOfWork(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<bool> SaveChangeAsync(CancellationToken cancellationToken)
    {
        return await context.SaveChangesAsync(cancellationToken) != 0;
    }


    public bool SaveChanges()
    {
        return context.SaveChanges() != 0;
    }
}

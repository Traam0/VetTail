using System.Threading.Tasks;
using System.Threading;

namespace VetTail.Domain.Common.Interfaces;

public interface IUnitOfWork
{
    bool SaveChanges();
    Task<bool> SaveChangeAsync(CancellationToken cancellationToken);
}

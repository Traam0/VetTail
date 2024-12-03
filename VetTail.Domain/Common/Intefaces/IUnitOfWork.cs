using System.Threading;
using System.Threading.Tasks;

namespace VetTail.Domain.Common.Intefaces;

public interface IUnitOfWork
{
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
}

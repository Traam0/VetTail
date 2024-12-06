using System.Threading;
using System.Threading.Tasks;

namespace VetTail.Domain.Common.Interfaces;

public interface IUnitOfWork
{
    bool SaveChanges();
    Task<bool> SaveChangeAsync(CancellationToken cancellationToken);

}

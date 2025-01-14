using System.Threading;
using System.Threading.Tasks;
using VetTail.Domain.Entities;

namespace VetTail.Application.Common.Interfaces;

public interface IAuthenticationService
{
    Task<User> LoginUser(string username, string password, CancellationToken cancellationToken = default);
}

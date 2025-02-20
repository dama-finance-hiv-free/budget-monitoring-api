using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Entity.Common;

namespace Dama.Fin.Domain.Contracts.Persistence.Common;

public interface IUserPersistence : IDataPersistence<User>
{
    Task<RepositoryActionResult<User>> ConnectUserAsync(User user);
    Task<RepositoryActionResult<User>> DisconnectUsersAsync(User user);
    Task DisconnectUsersAsync(User[] users);
    Task<User[]> GetConnectedUsersAsync(string tenant);
}
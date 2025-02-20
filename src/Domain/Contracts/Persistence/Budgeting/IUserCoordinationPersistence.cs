using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface IUserCoordinationPersistence : IDataPersistence<UserCoordination>
{
    Task<UserCoordination[]> GetUserCoordinationAsync(string tenant);
    Task<UserCoordination[]> GetUserCoordinationAsync(string tenant, string user);
    Task<RepositoryActionResult<UserCoordination[]>> UpdateUserCoordination(UserCoordination dto);
}
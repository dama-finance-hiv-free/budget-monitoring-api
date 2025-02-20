using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Entity.Common;
using Dama.Fin.Domain.Vm.Common;

namespace Dama.Fin.Domain.Contracts.Persistence.Common;

public interface IUserBranchPersistence : IDataPersistence<UserBranch>
{
    Task<string[]> GetUserBranchCodesAsync(string tenant, string user);
    Task<string> GetUserDefaultBranchAsync(string tenant, string user);
    Task<RepositoryActionResult<UserBranch[]>> UpdateUserBranchesAsync(UserBranchDto dto);
}
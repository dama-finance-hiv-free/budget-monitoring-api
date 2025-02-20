using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Common;

namespace Dama.Fin.Domain.Contracts.Service.Common;

public interface IUserBranchService : IServiceBase<UserBranchVm>
{
    Task<string> GetUserDefaultBranchAsync(string tenant, string user);
}
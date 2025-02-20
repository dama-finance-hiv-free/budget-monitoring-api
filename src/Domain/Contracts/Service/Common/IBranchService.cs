using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Common;

namespace Dama.Fin.Domain.Contracts.Service.Common;

public interface IBranchService : IServiceBase<BranchVm>
{
    Task<BranchVm[]> GetUserBranchesAsync(string tenant, string user);
    Task<BranchVm[]> GetBranchesAsync(string tenant);
    Task<string[]> GetBranchCodesAsync(string tenant);
}
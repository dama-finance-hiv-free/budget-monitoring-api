using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Budgeting;

public interface ITargetService : IServiceBase<TargetVm>
{
    Task<TargetVm[]> GetTargetsAsync(string tenant, string region);
}
using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Budgeting;

public interface IIncludeRunnerService : IServiceBase<IncludeRunnerVm>
{
    Task<IncludeRunnerVm[]> GetIncludeRunnersAsync(string tenant);
}
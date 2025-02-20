using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Budgeting;

public interface IRunnerService : IServiceBase<RunnerVm>
{
    Task<RunnerVm[]> GetRunnersAsync(string tenant);
    Task<string[]> GetRunnerCodesAsync(string tenant);
    Task<bool> RunnerIsActiveAsync(string tenant, string runner, string branch);
    Task<RunnerVm[]> GetAllRunnersByBranchAsync(string tenant, string region);
    Task<RunnerVm[]> GetAllRunnersByRegionAsync(string region);
}
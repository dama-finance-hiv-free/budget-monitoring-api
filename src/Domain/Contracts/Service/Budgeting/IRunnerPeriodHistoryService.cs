using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Budgeting;

public interface IRunnerPeriodHistoryService : IServiceBase<RunnerPeriodHistoryVm>
{
    Task<RunnerPeriodHistoryVm[]> GetRunnerPeriodHistoriesAsync(string tenant);
}
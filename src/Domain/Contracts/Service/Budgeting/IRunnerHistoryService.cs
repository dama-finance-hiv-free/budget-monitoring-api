using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Budgeting;

public interface IRunnerHistoryService : IServiceBase<RunnerHistoryVm>
{
    Task<RunnerHistoryVm[]> GetRunnerHistoriesAsync(string tenant);
}
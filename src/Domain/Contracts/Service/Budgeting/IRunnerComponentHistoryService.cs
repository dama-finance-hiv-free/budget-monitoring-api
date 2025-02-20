using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Budgeting;

public interface IRunnerComponentHistoryService : IServiceBase<RunnerComponentHistoryVm>
{
    Task<RunnerComponentHistoryVm[]> GetRunnerComponentHistoriesAsync(string tenant);
}
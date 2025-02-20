using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Budgeting;

public interface IRunnerPeriodService : IServiceBase<RunnerPeriodVm>
{
    Task<RunnerPeriodVm[]> GetRunnerPeriodsAsync(string tenant);
    Task<string[]> GetRunnerPeriodCodesAsync(string tenant);

    Task<string[]>
        GetRunnerPeriodHistoryCodesAsync(string tenant, string region, string copYear, string project);
}
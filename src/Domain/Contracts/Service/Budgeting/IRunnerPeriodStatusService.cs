using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Budgeting;

public interface IRunnerPeriodStatusService : IServiceBase<RunnerPeriodStatusVm>
{
    Task<RunnerPeriodStatusVm[]> GetRunnerPeriodsStatusAsync(string tenant);
}
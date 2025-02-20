using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Budgeting;

public interface IRunnerPeriodComponentService : IServiceBase<RunnerPeriodComponentVm>
{
    Task<RunnerPeriodComponentVm[]> GetRunnerPeriodComponentsAsync(string tenant);
}
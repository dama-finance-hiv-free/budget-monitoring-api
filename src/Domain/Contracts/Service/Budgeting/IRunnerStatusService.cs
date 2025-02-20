using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Budgeting;

public interface IRunnerStatusService : IServiceBase<RunnerStatusVm>
{

    Task<RunnerStatusVm[]> GetRunnersStatusAsync(string tenant);

}
using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Budgeting;

public interface IRunnerComponentService : IServiceBase<RunnerComponentVm>
{
    Task<RunnerComponentVm[]> GetRunnerComponentsAsync(string tenant);
}
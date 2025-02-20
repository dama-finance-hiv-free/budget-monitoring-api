using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Budgeting;

public interface ITargetHistoryService : IServiceBase<TargetHistoryVm>
{
    Task<TargetHistoryVm[]> GetUserTargetHistoriesAsync(string tenant);
}
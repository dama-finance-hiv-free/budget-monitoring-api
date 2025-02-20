using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Budgeting;

public interface IMilestoneService : IServiceBase<MilestoneVm>
{
    Task<MilestoneVm[]> GetMilestonesAsync(string tenant);
}
using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Budgeting;

public interface IRegionRunnerPeriodService : IServiceBase<RegionRunnerPeriodVm>
{
    Task<RegionRunnerPeriodVm[]> GetRegionRunnerPeriodsAsync(string tenant);
}